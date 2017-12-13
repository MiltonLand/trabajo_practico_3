using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Dtos;

namespace Services
{
    public class EmployeeService
    {
        private Repository<Employees> _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new Repository<Employees>();
        }

        public List<EmployeesDto> GetAll() {

            var employees = _employeeRepository.Set().Select(c => new EmployeesDto
            {
                EmployeeID = c.EmployeeID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CountryID = c.CountryID,
                Shift = c.Shift,
                HireDate = c.HireDate
            }).ToList();

            return employees;
        }

        public  EmployeesDto Find(int id)
        {
            var employee =  _employeeRepository.Set().FirstOrDefault(c => c.EmployeeID == id);

            var newEmployee = new EmployeesDto
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                CountryID = employee.CountryID,
                Shift = employee.Shift,
                HireDate = employee.HireDate
            };

            return newEmployee;
        }

        public void Create(EmployeesDto employee)
        {
            var newEmployee = new DataAccess.Employees
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                CountryID = employee.CountryID,
                Shift = employee.Shift,
                HireDate = employee.HireDate
            };

            _employeeRepository.Persist(newEmployee);
            _employeeRepository.SaveChanges();
        }
        public void Create(string fName, string lName, int countryId, string shift, DateTime hireDate)
        {
            var newEmployee = new Employees();
            newEmployee.FirstName = fName;
            newEmployee.LastName = lName;
            newEmployee.CountryID = countryId;
            newEmployee.Shift = shift;
            newEmployee.HireDate = hireDate;

            _employeeRepository.Persist(newEmployee);
            _employeeRepository.SaveChanges();
        }


        public void Update(EmployeesDto employee)
        {
            var newEmployee = _employeeRepository.Set().FirstOrDefault(c => c.EmployeeID == employee.EmployeeID);

            newEmployee.EmployeeID = employee.EmployeeID;
            newEmployee.FirstName = employee.FirstName;
            newEmployee.LastName = employee.LastName;
            newEmployee.CountryID = employee.CountryID;
            newEmployee.Shift = employee.Shift;
            newEmployee.HireDate = employee.HireDate;

            _employeeRepository.SaveChanges();
        }

        public void Delete(EmployeesDto employee)
        {
            var newEmployee = _employeeRepository.Set().FirstOrDefault(c => c.EmployeeID == employee.EmployeeID);

            _employeeRepository.Remove(newEmployee);
            _employeeRepository.SaveChanges();

        }
    }
}
