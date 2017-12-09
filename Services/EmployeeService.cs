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
            var ER = new EmployeeRepository();
              var list= ER.GetEmployeesInclude();
            return list;
        }


        public static Employees FindID(int? id)
        {
            var ER = new EmployeeRepository();
            return ER.FindID(id);
           
        }

    }
}
