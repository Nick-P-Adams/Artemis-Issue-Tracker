using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis_Issue_Tracker.Models
{
    public class Log
    {
        [Key]
        public int id { get; set; }
        public string type { get; set; }
        public string log { get; set; }
        public DateTime created { get; set; }

        // Foreign Keys
        [ForeignKey("user")]
        public string? user_id { get; set; }

        [ForeignKey("task")]
        public int? task_id { get; set; }

        // Navigation Properties
        public IdentityUser? user { get; set; }
        public Task? task { get; set; }

        public Log() 
        {
            type = string.Empty;
            log = string.Empty;
            created = DateTime.Now;
        }
    }
}
