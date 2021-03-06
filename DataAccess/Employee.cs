namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public Employee()
        {
            WorkingDays = new HashSet<WorkingDay>();
        }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int CountryID { get; set; }

        [StringLength(50)]
        public string Shift { get; set; }

        public DateTime? HiringDate { get; set; }

        public decimal HourlyWage { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<WorkingDay> WorkingDays { get; set; }
    }
}
