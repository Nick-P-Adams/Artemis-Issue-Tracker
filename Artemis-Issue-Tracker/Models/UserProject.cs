using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace Artemis_Issue_Tracker.Models
{
    public class UserProject
    {
        [Key]
        public string UserId { get; set; }
        public int ProjectId { get; set; }

        public UserProject() {}
    }
}
