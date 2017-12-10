namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Turns
    {
        public Turns()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        public int TurnID { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Turno")]
        public string Description { get; set; }
        [DisplayName("Hora de ingreso")]
        public TimeSpan TimeIn { get; set; }
        [DisplayName("Hora de salida")]
        public TimeSpan TimeOut { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
