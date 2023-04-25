using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artemis_Issue_Tracker.Models
{
    public class UserProject
    {
        public string UserId { get; set; }

        [Key]
        public int ProjectId { get; set; }

        public UserProject() {}
    }
}
