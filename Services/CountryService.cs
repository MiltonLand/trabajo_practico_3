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
        
        public void Create(string name)
        {
            if (!this.Exists(name))
            {
                this.AddToDatabase(new Country() {
                    CountryName = name
                });
            }
        }

        public CountryDto Read(int id)
        {
            var country = GetCountry(id);

            if (country == null)
                return null;

            return new CountryDto
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName
            };
        }
        public CountryDto Read(string countryName)
        {
            var country = GetCountry(countryName);

            if (country == null)
                return null;

            return new CountryDto
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName
            };
        }

        public void Update(CountryDto countryDto)
        {
            if(this.Exists(countryDto.CountryName))
            {
                var country = GetCountry(countryDto);

                if (country == null)
                    return;

                country.CountryName = countryDto.CountryName;

                _countryRepository.SaveChanges();
            }
        }

        public void Update(int countryId, string newName)
        {
            if (this.Exists(countryId))
            {
                var country = GetCountry(countryId);

                if (country == null)
                    return;

                country.CountryName = newName;

                _countryRepository.SaveChanges();
            }
        }
        public void Update(string currentName, string newName)
        {
            if (this.Exists(currentName))
            {
                var country = GetCountry(currentName);

                if (country == null)
                    return;

                country.CountryName = newName;

                _countryRepository.SaveChanges();
            }
        }

        public void Delete(CountryDto countryDto)
        {
            var country = GetCountry(countryDto);

            this.DeleteFromDatabase(country);
        }
        public void Delete(int countryId)
        {
            var country = GetCountry(countryId);

            this.DeleteFromDatabase(country);
        }

        public bool CheckHasEmployees(int id)
        {
            var _employeeRepository = new Repository<Employee>();

            var hasEmployee = _employeeRepository 
                 .Set()
                 .Where(e => e.CountryID==id)
                 .Any();

            return hasEmployee;
        }

        public void Delete(string countryName)
        {
            var country = GetCountry(countryName);
            
            this.DeleteFromDatabase(country);
        }

        private Country GetCountry(CountryDto countryDto)
        {
            var country = _countryRepository
                 .Set()
                 .FirstOrDefault(c => c.CountryID == countryDto.CountryID);

            if (country == null)
                country = _countryRepository
                             .Set()
                             .FirstOrDefault(c => c.CountryName == countryDto.CountryName);

            return country;
        }
        private Country GetCountry(int countryId)
        {
            return _countryRepository
                   .Set()
                   .FirstOrDefault(c => c.CountryID == countryId);
        }
        private Country GetCountry(string countryName)
        {
            return _countryRepository
                   .Set()
                   .FirstOrDefault(c => c.CountryName == countryName);
        }
        private void AddToDatabase(Country c)
        {
            _countryRepository.Persist(c);
            _countryRepository.SaveChanges();
        }
        private void DeleteFromDatabase(Country c)
        {
            if (c == null)
                return;

            _countryRepository.Remove(c);
            _countryRepository.SaveChanges();
        }
        private bool Exists(int countryId)
        {
            return _countryRepository
                   .Set()
                   .Any(c => c.CountryID == countryId);
        }
        private bool Exists(string countryName)
        {
            return _countryRepository
                   .Set()
                   .Any(c => c.CountryName == countryName);
        }
    }
}
