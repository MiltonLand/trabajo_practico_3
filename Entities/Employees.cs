namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int CountryID { get; set; }

        public int TurnID { get; set; }

        public DateTime? HireDate { get; set; }

        public virtual Country Country { get; set; }

        public virtual Turns Turns { get; set; }
    }
}
