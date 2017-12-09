namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Turnos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Turnos()
        {
            Empleados = new HashSet<Empleados>();
        }

        [Key]
        public int TurnoID { get; set; }

        [Required]
        [StringLength(25)]
        public string Descripcion { get; set; }

        public TimeSpan HoraIngreso { get; set; }

        public TimeSpan HoraSalida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
