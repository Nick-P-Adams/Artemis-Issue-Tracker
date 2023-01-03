namespace Artemis_Issue_Tracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int SprintLength { get; set; }
        public int SprintCount { get; set; }

        public Project(){}
    }
}
