namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entidades;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paises>()
                .HasMany(e => e.Empleados)
                .WithRequired(e => e.Paises)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turnos>()
                .HasMany(e => e.Empleados)
                .WithRequired(e => e.Turnos)
                .WillCascadeOnDelete(false);
        }
    }
}
