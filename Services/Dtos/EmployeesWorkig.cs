using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.Dtos.EmployeeDto;

namespace Services.Dtos
{
    public class EmployeesWorkig
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Shifts Shift { get; set; }

        public DateTime? TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public int? WorkedHours { get; set; }
    }
}
