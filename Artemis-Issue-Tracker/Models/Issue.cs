namespace Artemis_Issue_Tracker.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String AttachmentURL { get; set; }
        public DateTime CreationDate { get; set; }
        public int SprintCount { get; set; }

        public Issue(){}
    }
}
