using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Artemis_Issue_Tracker.Models;
using Microsoft.AspNetCore.Identity;

namespace Artemis_Issue_Tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
        public DbSet<Artemis_Issue_Tracker.Models.Project> Project { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.Task> Task { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.Sprint> Sprint { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.Comment> Comment { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.Log> Log { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.Resource> Resource { get; set; }
        public DbSet<Artemis_Issue_Tracker.Models.UserProject> UserProject { get; set; }
    }
}