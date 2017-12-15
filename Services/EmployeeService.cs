﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Dtos;
using static Services.Dtos.EmployeeDto;

namespace Services
{
    public class EmployeeService
    {
        private Repository<Employee> _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new Repository<Employee>();
        }

        public List<EmployeeDto> GetAll()
        {
            var listEmployeesDtos = new List<EmployeeDto>();

            foreach (var e in _employeeRepository.Set())
                listEmployeesDtos.Add(ConvertToDto(e));

            return listEmployeesDtos;
        }
        
        public void Create(EmployeeDto employeeDto)
        {
            this.AddToDatabase(CreateFromDto(employeeDto));
        }

        public EmployeeDto Read(int id)
        {
            var employee = _employeeRepository
                           .Set()
                           .FirstOrDefault(c => c.EmployeeID == id);

            if (employee == null)
                return null;

            return ConvertToDto(employee);
        }

        public void Update(EmployeeDto employeeDto)
        {
            if (ValidDto(employeeDto))
            {
                var employee = _employeeRepository
                                  .Set()
                                  .FirstOrDefault(c => c.EmployeeID == employeeDto.EmployeeID);

                if (employee == null)
                    return;

                var countryService = new CountryService();

                var country = countryService.Read(employeeDto.Country);
                var shift = this.ShiftToString(employeeDto.Shift);

                employee.EmployeeID = employeeDto.EmployeeID;
                employee.FirstName = employeeDto.FirstName;
                employee.LastName = employeeDto.LastName;
                employee.CountryID = country.CountryID;
                employee.Shift = shift;
                employee.HiringDate = employeeDto.HiringDate;
                employee.HourlyWage = employeeDto.HourlyWage;

                _employeeRepository.SaveChanges();
            }
        }

        public void Delete(EmployeeDto employee)
        {
            this.DeleteFromDatabase(_employeeRepository
                                    .Set()
                                    .FirstOrDefault(c => c.EmployeeID == employee.EmployeeID));
        }
        public void Delete(int employeeId)
        {
            this.DeleteFromDatabase(_employeeRepository
                                    .Set()
                                    .FirstOrDefault(c => c.EmployeeID == employeeId));
        }

        public string ShiftToString(Shifts s)
        {
            string shift;

            switch (s)
            {
                case Shifts.FirstShift:
                    shift = "Mañana";
                    break;
                case Shifts.SecondShift:
                    shift = "Tarde";
                    break;
                case Shifts.ThirdShift:
                    shift = "Noche";
                    break;
                default:
                    shift = "NULL";
                    break;
            }

            return shift;
        }
        public Shifts StringToShift(string s)
        {
            Shifts shift;

            switch (s.ToLower())
            {
                case "mañana":
                    shift = Shifts.FirstShift;
                    break;
                case "tarde":
                    shift = Shifts.SecondShift;
                    break;
                case "noche":
                    shift = Shifts.ThirdShift;
                    break;
                default:
                    shift = Shifts.FirstShift;
                    break;
            }

            return shift;
        }

        //Auxiliary functions
        private void AddToDatabase(Employee e)
        {
            if (e == null)
                return;

            _employeeRepository.Persist(e);
            _employeeRepository.SaveChanges();
        }
        private void DeleteFromDatabase(Employee e)
        {
            if (e == null)
                return;

            _employeeRepository.Remove(e);
            _employeeRepository.SaveChanges();
        }
        private EmployeeDto ConvertToDto(Employee e)
        {
            var countryService = new CountryService();
            var country = countryService.Read(e.CountryID);

            return new EmployeeDto
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Country = country.CountryName,
                Shift = StringToShift(e.Shift),
                HiringDate = e.HiringDate,
                HourlyWage = e.HourlyWage
            };
        }
        private Employee CreateFromDto(EmployeeDto employeeDto)
        {
            if (ValidDto(employeeDto))
            {
                var countryService = new CountryService();
                var country = countryService.Read(employeeDto.Country);
                var shift = this.ShiftToString(employeeDto.Shift);

                return new Employee()
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    CountryID = country.CountryID,
                    Shift = shift,
                    HiringDate = employeeDto.HiringDate,
                    HourlyWage = employeeDto.HourlyWage
                };
            }

            return null;
        }
        private bool ValidDto(EmployeeDto employeeDto)
        {
            return ValidString(employeeDto.FirstName)      &&
                   ValidString(employeeDto.LastName)       &&
                   ValidCountryName(employeeDto.Country)   &&
                   ValidHiringDate(employeeDto.HiringDate) &&
                   ValidWage(employeeDto.HourlyWage);
        }

        //Individual Validations
        private bool ValidString(string s)
        {
            //Verdadero si la cadena no es vacía, 
            //tiene longitud mayor a 2 y menor o igual a 50, 
            //y no tiene digitos.
            var len = s.Count();
            return ((s != "")  && 
                    (len > 2)  && 
                    (len <= 50) && 
                    (!s.Any(c => char.IsDigit(c))));
        }
        private bool ValidCountryName(string countryName)
        {
            if (!ValidString(countryName))
                return false;

            var countryService = new CountryService();

            var country = countryService.Read(countryName);

            return (country != null);
        }
        private bool ValidHiringDate(DateTime? hiringDate)
        {
            if (hiringDate != null)
                return (hiringDate <= DateTime.Today);

            return true;
        }
        private bool ValidWage(decimal hourlyWage)
        {
            return (hourlyWage > 0);
        }
    }
}
