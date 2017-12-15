namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkingDay")]
    public partial class WorkingDay
    {
        public int WorkingDayID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public int? WorkedHours { get; set; }

        public virtual Employee Employees { get; set; }
    }
}
