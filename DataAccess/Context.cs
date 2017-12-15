namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<WorkingDay> WorkingDay { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.HourlyWage)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkingDay)
                .WithRequired(e => e.Employees)
                .WillCascadeOnDelete(false);
        }
    }
}
