// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Allows for sorting of backlog tasks and updates their position attribute when needed
$(document).ready(function () {
    enableAccordionToggle();

    $(".accordion").sortable({
        update: function (event, ui) {
            // Retrieve the sorted task IDs
            var sortedTaskIds = [];
            $(".task_t1").each(function () {
                var task = $(this).data("task-id");
                sortedTaskIds.push(task);
            });
            console.log(sortedTaskIds);

            // Send the sorted task IDs to the server for saving the new order
            $.ajax({
                url: "/Tasks/UpdatePositions",
                type: "POST",
                data: { taskIds: sortedTaskIds },
                success: function () {
                    console.log("Task Order Updated Successfully.");
                },
                error: function () {
                    console.log("Failed To Update Task Order.");
                }
            });
        }
    });

    $(document).on('click', '.create-task-button', loadCreateTaskModal);

    $(document).on('click', '.save-task-button', function () {
        var taskData = {}; // Object to store the task data
        var token = $('input[name="__RequestVerificationToken"]').val();

        $('.createTaskForm input').each(function () {
            var field = $(this).data('field');
            var value = $(this).val();
            taskData[field] = value;
        });

        $.ajax({
            url: '/Tasks/Create',
            method: 'POST',
            data: taskData,
            headers: {'RequestVerificationToken': token},
            success: function (response) {
                if (response.success) {
                    var parentId = taskData["parent_id"];
                    var parentAccordion = $(`#accordion-${parentId}`);
                    var accordionItem;

                    if (parentId == "") {
                        accordionItem = createAccordionItem(response.id, taskData["name"]);
                        $("#create-task-item").before(accordionItem);
                    }
                    else {
                        accordionItem = createAccordionItem(response.id, taskData["name"]);

                        // bad solution find better solution
                        if (parentAccordion.className == "accordion-final") {
                            accordionItem = createT3AccordionItem(response.id, taskData["name"]);
                        }

                        parentAccordion.append(accordionItem);
                    }

                    // Could make this more efficient but having a varriant that is passed only the new element that may need toggle enabled
                    enableAccordionToggle();
                    $('#createTaskModal').modal('hide');
                    console.log("Task Created Successfully.");
                } else {
                    var errors = response.errors;

                    for (var fieldName in errors) {
                        var errorMessages = errors[fieldName];
                        var errorElement = $('[data-valmsg-for="' + fieldName + '"]');
                        errorElement.text(errorMessages);
                    }
                }
            },
            error: function (xhr, status, error) {
                console.log("Failed To Create Task.");
            }
        });
    });
});

function loadCreateTaskModal() {
    $.get('/Tasks/GetCreateTaskModal', function (data) {
        $('.create-task-container').html(data);
        $('#createTaskModal').modal('show');
    });
}

function enableAccordionToggle() {
    $(".accordion-button").each(function () {
        var count = $(this).data('subtask-count');

        if (count != "" && count > 0) {
            $(this).attr('data-bs-toggle', 'collapse');
        }
    });
}

function createAccordionItem(taskId, taskName) {
    var accordionItem = document.createElement("div");
    accordionItem.className = `accordion-item`;
    accordionItem.setAttribute('data-task-id', taskId);

    // Create the accordion-header element
    var accordionHeader = document.createElement('h2');
    accordionHeader.classList.add('accordion-header');

    // Create the button element
    var button = document.createElement('button');
    button.classList.add('accordion-button');
    button.setAttribute('type', 'button');
    button.setAttribute('data-bs-target', `#task-${taskId}`);
    button.setAttribute('data-subtask-count', 0);
    button.setAttribute('aria-expanded', 'false');
    button.setAttribute('aria-controls', `task-${taskId}`);
    button.textContent = taskName;

    // Constructing the accordion item heirarchy
    accordionHeader.appendChild(button);
    accordionItem.appendChild(accordionHeader);

    return accordionItem;
}

function createT3AccordionItem(taskId, taskName) {
    var accordionItem = document.createElement("div");
    accordionItem.className = `accordion-item`;
    accordionItem.setAttribute('data-task-id', taskId);

    // Create the accordion-header element
    var accordionHeader = document.createElement('h2');
    accordionHeader.classList.add('accordion-header');

    // Create the button element
    var button = document.createElement('button');
    button.classList.add('accordion-button');
    button.setAttribute('type', 'button');
    button.textContent = taskName;

    // Constructing the accordion item heirarchy
    accordionHeader.appendChild(button);
    accordionItem.appendChild(accordionHeader);

    return accordionItem;
}