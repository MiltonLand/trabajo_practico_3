using Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmployeeRepository : BaseRepository<Employees>
    {


        public List<Employees> GetEmployeesInclude()
        {
            using (DataModel context = new DataModel())
            {
                var list = context.Employees.Include(e => e.Country).Include(e => e.Turns).ToList();
                return list;
            }
        }


        public Employees FindID(int? id)
        {
            using (DataModel context = new DataModel())
            {
                return context.Employees.Find(id);

            }
        }

        public Employees FindInclude(int? id)
        {
            using (DataModel context = new DataModel())
            {
                return context.Employees.Include(e => e.Country).Include(e => e.Turns).Where(e=>e.EmployeeID==id).FirstOrDefault();

            }
        }

    }
}
