using Microsoft.EntityFrameworkCore;

namespace TaskMangeSystem.Models
{
    public class appdbcontext :DbContext
    {
        public appdbcontext(DbContextOptions<appdbcontext> options) : base(options) { }
        
        public DbSet<task> tasks { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<TeamMember> teamMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<task>().HasOne(i=>i.Project).WithMany(i=>i.tasks).HasForeignKey(u=>u.ProjectId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<task>().HasOne(i => i.TeamMember).WithMany(i => i.tasks).HasForeignKey(u => u.TeamMemberid).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }


    }
}
