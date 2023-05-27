using System.ComponentModel.DataAnnotations;

namespace Artemis_Issue_Tracker.Models
{
    public class UserProject
    {
        [Key]
        public string user_id { get; set; }

        public int project_id { get; set; }
    }
}
