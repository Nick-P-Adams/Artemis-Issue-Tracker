namespace Artemis_Issue_Tracker.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public String Item { get; set; }
        public DateTime CreationDate { get; set; }

        public Comment(){}
    }
}
