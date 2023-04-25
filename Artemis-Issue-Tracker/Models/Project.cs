namespace Artemis_Issue_Tracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Summary { get; set; }
        public DateTime CreationDate { get; set; }

        public Project(){}
    }
}
