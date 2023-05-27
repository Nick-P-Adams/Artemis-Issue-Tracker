using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis_Issue_Tracker.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public bool favorite { get; set; }
        public DateTime sprint_length { get; set; }
        public DateTime created { get; set; }

        // Navigation Properties
        public ICollection<Task>? tasks { get; set; }
        public ICollection<Sprint>? sprints { get; set; }

        public Project() 
        {
            name = string.Empty;
            description = string.Empty;
            type = string.Empty;
            progress = 0;
            favorite = false;
            sprint_length = DateTime.MinValue;
            created = DateTime.Now;
        } 
    }
}
