using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Dtos;

namespace Services
{
    public class CountryService
    {
        private Repository<Country> _countryRepository;

        public CountryService()
        {
            _countryRepository = new Repository<Country>();
        }

        public List<CountryDto> GetAll()
        {
            return _countryRepository.Set().Select(c => new CountryDto
            {
                CountryID = c.CountryID,
                CountryName = c.CountryName
            }).ToList();
        }
    }
}
