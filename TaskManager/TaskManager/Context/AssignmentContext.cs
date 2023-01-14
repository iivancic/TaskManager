using Microsoft.EntityFrameworkCore;

namespace TaskManager.Context
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext(DbContextOptions<AssignmentContext> options) : base(options) { }

        public DbSet<Models.Assignment> Tasks { get; set;}
        public DbSet<Models.Member> Members { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Assignment>().ToTable("Task");
            modelBuilder.Entity<Models.Member>().ToTable("Member");
        }
    }
}
