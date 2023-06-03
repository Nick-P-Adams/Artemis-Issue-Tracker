using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis_Issue_Tracker.Models
{
    public class Task
    {
        //add default values
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int progress { get; set; }
        public DateTime time_estimate { get; set; }
        public DateTime time_log { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public DateTime created { get; set; }

        // Foreign Keys
        [ForeignKey("project")]
        public int? project_id { get; set; }

        [ForeignKey("parent")]
        public int? parent_id { get; set; }

        [ForeignKey("sprint")]
        public int? sprint_id { get; set; }

        // Navigation Properties
        public Project? project { get; set; }
        public Task? parent { get; set; }
        public Sprint? sprint { get; set; }
        public ICollection<Task> sub_tasks { get; set; }
        public ICollection<Comment>? comments { get; set; }
        public ICollection<Log>? logs { get; set; }
        public ICollection<Resource>? resources { get; set; }

        public Task() 
        { 
            // Need to rethink some default values such as for status and type
            // Default value settings should be in an .env file somwhere
            name = string.Empty;
            description= string.Empty;
            status = string.Empty;
            type = string.Empty;
            priority = 0;
            position = 0;
            progress = 0;
            time_estimate = DateTime.MinValue;
            time_log = DateTime.MinValue;
            start = DateTime.MinValue;
            end = DateTime.MinValue;
            created = DateTime.Now;
            sub_tasks = new List<Task>();
        }
    }
}
