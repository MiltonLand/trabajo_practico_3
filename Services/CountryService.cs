using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class CountryService
    {
        public static List<Country> GetAll()
        {
            var CR = new CountryRepository();
            return CR.GetAll();
        }
    }
}
