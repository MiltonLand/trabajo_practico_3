namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Empleados
    {
        [Key]
        public int EmpleadoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public int PaisID { get; set; }

        public int TurnoID { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public virtual Paises Paises { get; set; }

        public virtual Turnos Turnos { get; set; }
    }
}
