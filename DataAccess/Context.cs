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
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<WorkingDay> WorkingDay { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.WorkingDay)
                .WithRequired(e => e.Employees)
                .WillCascadeOnDelete(false);
        }
    }
}
