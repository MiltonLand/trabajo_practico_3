﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    public class EmployeesDto
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountryID { get; set; }

        public int Shift { get; set; }

        public DateTime? HireDate { get; set; }

    }
}
