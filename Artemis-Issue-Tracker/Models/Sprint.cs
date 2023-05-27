using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis_Issue_Tracker.Models
{
    public class Sprint
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public DateTime created { get; set; }

        // Foreign Keys
        [ForeignKey("project")]
        public int project_id { get; set; }

        // Navigation Properties
        public Project? project { get; set; }
        public ICollection<Task>? tasks { get; set; }

        public Sprint() 
        { 
            name = string.Empty;
            start = DateTime.MinValue;
            end = DateTime.MinValue;
            created = DateTime.Now;
        }
    }
}
