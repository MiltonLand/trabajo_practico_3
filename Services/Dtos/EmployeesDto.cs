using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class EmployeeDto
    {
        public enum Shifts {
            FirstShift,
            SecondShift,
            ThirdShift
        }

        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountryID { get; set; }

        //public string CountryName { get; set; }

        public Shifts Shift { get; set; }

        public DateTime? HiringDate { get; set; }

        public decimal HourlyWage { get; set; }
    }
}
