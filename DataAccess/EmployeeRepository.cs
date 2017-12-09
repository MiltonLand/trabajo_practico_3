﻿using Entities;
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
                var list = context.Employees.Include(e => e.Country).Include(e => e.Turns);
                return list.ToList();
            }
        }


        public Employees FindID(int? id)
        {
            using (DataModel context = new DataModel())
            {
                return context.Employees.Find(id);

            }
        }

    }
}
