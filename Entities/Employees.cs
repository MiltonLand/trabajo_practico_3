namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName ("Nombre")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Apellido")]
        public string LastName { get; set; }
        [DisplayName("País")]
        public int CountryID { get; set; }
        [DisplayName("Turno")]
        public int TurnID { get; set; }
        [DisplayName("Fecha de contratación")]
        public DateTime? HireDate { get; set; }
        [DisplayName("País")]
        public virtual Country Country { get; set; }
        [DisplayName("Turno")]
        public virtual Turns Turns { get; set; }
    }
}
