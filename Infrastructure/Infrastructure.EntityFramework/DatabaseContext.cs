using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<Employee>().Property(c => c.FirstName).HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(c => c.LastName).HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(c => c.Email).HasMaxLength(100);

            modelBuilder.Entity<Role>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<Role>().Property(c => c.Description).HasMaxLength(100);
    }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
