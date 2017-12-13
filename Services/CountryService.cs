﻿using DataAccess;
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

        public CountryDto Find(int id)
        {
            var country = _countryRepository.Set().FirstOrDefault(c => c.CountryID == id);

            var newCountry = new CountryDto
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName
            };

            return newCountry;
        }

        public void Create(CountryDto country)
        {
            var newCountry = new Country
            {
                CountryName = country.CountryName
            };

            _countryRepository.Persist(newCountry);
            _countryRepository.SaveChanges();
        }

        public void Create(string name)
        {
            var newCountry = new Country();
            
            newCountry.CountryName = name;

            _countryRepository.Persist(newCountry);
            _countryRepository.SaveChanges();
        }


        public void Update(CountryDto country)
        {
            if(countryAlreadyExists(country.CountryName))
            {
                var newCountry = _countryRepository.Set()
                //.Where(c => c.CountryName != country.CountryName)
                .FirstOrDefault(c => c.CountryID == country.CountryID);

                newCountry.CountryName = country.CountryName;

                _countryRepository.SaveChanges();
            }
            else
            {
                
            }
            return;
        }

        public void Delete(CountryDto country)
        {
            var newCountry = _countryRepository.Set().FirstOrDefault(c => c.CountryID == country.CountryID);

            _countryRepository.Remove(newCountry);
            _countryRepository.SaveChanges();

        }

        public bool countryAlreadyExists(string countryName)
        {
            var exists = _countryRepository.Set()
                .Where(c => c.CountryName == countryName)
                .Any();

            return exists;
        }
    }
}
