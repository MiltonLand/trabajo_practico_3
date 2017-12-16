namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Employees = new HashSet<Employee>();
        }

        public int CountryID { get; set; }

        [Required]
        [StringLength(20)]
        public string CountryName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
