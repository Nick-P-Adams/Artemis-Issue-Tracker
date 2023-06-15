// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Allows for sorting of backlog tasks and updates their position attribute when needed
$(document).ready(function () {
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

    $('.saveTaskButton').on('click', function () {
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
                    console.log("Task Created Successfully.");
                } else {
                    var errors = response.errors;

                    // Update the specific elements inside the modal with the validation errors
                    for (var fieldName in errors) {
                        var errorMessages = errors[fieldName];
                        var errorElement = $('[data-valmsg-for="' + fieldName + '"]');
                        errorElement.text(errorMessages.join(', '));
                    }
                }
            },
            error: function (xhr, status, error) {
                console.log("Failed To Create Task.");
            }
        });
    });
});