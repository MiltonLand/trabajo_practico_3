using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class WorkingDayDto
    {
        public int WorkingDayID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public decimal? HoursWorked { get; set; }
    }
}
