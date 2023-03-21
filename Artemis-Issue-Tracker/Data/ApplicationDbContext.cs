using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Artemis_Issue_Tracker.Models;

namespace Artemis_Issue_Tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Artemis_Issue_Tracker.Models.Checklist> Checklist { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.Comment> Comment { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.Issue> Issue { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.Project> Project { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.UserProject> UserProject { get; set; }
    }
}