using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class EmployeeService
    {
        public static List<Employees> GetAll() {
            var EmployeeRep = new EmployeeRepository();
              var list = EmployeeRep.GetEmployeesInclude();
            return list;
        }

        public static Employees FindID(int? id)
        {
            var EmployeeRep = new EmployeeRepository();
            return EmployeeRep.FindID(id);
           
        }

        public static void Add(Employees employee)
        {
            var EmployeeRep = new EmployeeRepository();
            EmployeeRep.Create(employee);

        }
    }
}
