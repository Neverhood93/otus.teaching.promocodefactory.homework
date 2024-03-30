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

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Preference> Preference { get; set; }

        public DbSet<CustomerPreference> CustomerPreference { get; set; }

        public DbSet<PromoCode> PromoCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<PromoCode>()
                .HasOne(pc => pc.Customer)
                .WithMany(c => c.PromoCodes)
                .HasForeignKey(pc => pc.CustomerId);

            modelBuilder.Entity<PromoCode>()
                .HasOne(pc => pc.Preference)
                .WithMany(p => p.PromoCodes)
                .HasForeignKey(pc => pc.PreferenceId);


            modelBuilder.Entity<CustomerPreference>()
                .HasKey(cp => new { cp.CustomerId, cp.PreferenceId });

            modelBuilder.Entity<CustomerPreference>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerPreferences)
                .HasForeignKey(cp => cp.CustomerId);

            modelBuilder.Entity<CustomerPreference>()
                .HasOne(cp => cp.Preference)
                .WithMany(c => c.CustomerPreferences)
                .HasForeignKey(cp => cp.PreferenceId);


            modelBuilder.Entity<Employee>().Property(x => x.FirstName).HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(x => x.LastName).HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(x => x.Email).HasMaxLength(100);

            modelBuilder.Entity<Customer>().Property(x => x.FirstName).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(x => x.LastName).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(x => x.Email).HasMaxLength(100);

            modelBuilder.Entity<Preference>().Property(x => x.Name).HasMaxLength(100);

            modelBuilder.Entity<PromoCode>().Property(x => x.Code).HasMaxLength(100);

            modelBuilder.Entity<Role>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Role>().Property(x => x.Description).HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
