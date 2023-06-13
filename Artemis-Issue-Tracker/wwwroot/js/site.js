// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
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
                    console.log("Task order updated successfully.");
                },
                error: function () {
                    console.log("Failed to update task order.");
                }
            });
        }
    });
});

$(document).ready(function () {
    // Initialize the modal
    const modal = document.getElementById('myModal');
    const myModal = new bootstrap.Modal(modal);
});