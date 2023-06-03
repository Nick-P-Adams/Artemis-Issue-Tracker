using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Artemis_Issue_Tracker.Models;

namespace Artemis_Issue_Tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
        public DbSet<Project>? Project { get; set; }
        public DbSet<Models.Task>? Task { get; set; }
        public DbSet<Sprint>? Sprint { get; set; }
        public DbSet<Comment>? Comment { get; set; }
        public DbSet<Log>? Log { get; set; }
        public DbSet<Resource>? Resource { get; set; }
        public DbSet<UserProject>? UserProject { get; set; }
    }
}