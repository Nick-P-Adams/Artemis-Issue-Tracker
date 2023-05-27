using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis_Issue_Tracker.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public string comment { get; set; }
        public DateTime created { get; set; }

        // Foreign Keys
        [ForeignKey("user")]
        public string? user_id { get; set; }
        
        [ForeignKey("task")]
        public int? task_id { get; set; }

        // Navigation Properties
        public IdentityUser? user { get; set; }
        public Task? task { get; set; }
        public ICollection<Resource>? resources { get; set; }

        public Comment() 
        {
            comment = string.Empty;
            created = DateTime.Now;
        }
    }
}
