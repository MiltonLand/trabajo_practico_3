namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Employees = new HashSet<Employees>();
        }

        public int CountryID { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("País")]
        public string CountryName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
