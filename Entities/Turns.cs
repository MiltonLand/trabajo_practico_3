namespace Entities
{
    using System;
    using System.Collections.Generic;
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
        public string Description { get; set; }

        public TimeSpan TimeIn { get; set; }

        public TimeSpan TimeOut { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
