using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis_Issue_Tracker.Models
{
    public class Resource
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public int option { get; set; }
        public DateTime created { get; set; }

        // Foreign Keys
        [ForeignKey("user")]
        public string? user_id { get; set; }

        [ForeignKey("task")]
        public int? task_id { get; set; }

        [ForeignKey("comment")]
        public int? comment_id { get; set; }

        // Navigation Properties
        public IdentityUser? user { get; set; }
        public Task? task { get; set; }
        public Comment? comment { get; set; }

        public Resource() 
        {
            name = string.Empty;
            type = string.Empty;
            uri = string.Empty;
            option = 0;
            created = DateTime.Now;
        }
    }
}
