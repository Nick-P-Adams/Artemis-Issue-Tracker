using Artemis_Issue_Tracker.Models;
using X.PagedList;

namespace Artemis_Issue_Tracker
{
    public class ProjectViewModel
    {
        public IPagedList<Project> Projects { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
