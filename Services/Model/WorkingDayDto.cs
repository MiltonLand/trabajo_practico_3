using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    public class WorkingDayDto
    {
        public int EmployeeID { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

    }
}
