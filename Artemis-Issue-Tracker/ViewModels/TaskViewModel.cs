using Task = Artemis_Issue_Tracker.Models.Task;

namespace Artemis_Issue_Tracker.ViewModels
{
    public class TaskViewModel
    {
        public IEnumerable<Task> Epics { get; set;}
        public IEnumerable<Task> Stories { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
        public IEnumerable<Task> Bugs { get; set; }

        public TaskViewModel() 
        {
            Epics = new List<Task>();
            Stories = new List<Task>();
            Tasks = new List<Task>();
            Bugs = new List<Task>();
        }
    }
}
