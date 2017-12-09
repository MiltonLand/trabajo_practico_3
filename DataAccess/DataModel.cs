namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entities;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Turns> Turns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turns>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Turns)
                .WillCascadeOnDelete(false);
        }
    }
}
