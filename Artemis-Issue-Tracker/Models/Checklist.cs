namespace Artemis_Issue_Tracker.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public String Item { get; set; }
        public bool State { get; set; }
        public DateTime CreationDate { get; set; }

        public Checklist(){}
    }
}
