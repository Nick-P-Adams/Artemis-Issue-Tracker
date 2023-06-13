using Task = Artemis_Issue_Tracker.Models.Task;

namespace Artemis_Issue_Tracker.ViewModels
{
    public class TaskViewModel
    {
        public Task Task { get; set; }
        public List<TaskViewModel> SubTasks { get; set; }
    }
}
