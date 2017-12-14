using DataAccess;
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

        public EmployeeDto Find(int id)
        {
            var employee =  _employeeRepository.Set().FirstOrDefault(c => c.EmployeeID == id);

            if (employee == null)
                return null;

            return ConvertToDto(employee);
        }

        public void Create(EmployeeDto employee)
        {
            var newEmployee = CreateFromDto(employee);

            _employeeRepository.Persist(newEmployee);
            _employeeRepository.SaveChanges();
        }

        public void Update(EmployeeDto employee)
        {
            var newEmployee = _employeeRepository.Set().FirstOrDefault(c => c.EmployeeID == employee.EmployeeID);

            newEmployee.EmployeeID = employee.EmployeeID;
            newEmployee.FirstName = employee.FirstName;
            newEmployee.LastName = employee.LastName;
            newEmployee.CountryID = employee.CountryID;
            newEmployee.Shift =  ShiftToString(employee.Shift);
            newEmployee.HiringDate = employee.HiringDate;
            newEmployee.HourlyWage = employee.HourlyWage;

            _employeeRepository.SaveChanges();
        }

        public void Delete(EmployeeDto employee)
        {
            var newEmployee = _employeeRepository.Set().FirstOrDefault(c => c.EmployeeID == employee.EmployeeID);

            _employeeRepository.Remove(newEmployee);
            _employeeRepository.SaveChanges();
        }
        public void Delete(int employeeId)
        {
            var newEmployee = _employeeRepository.Set().FirstOrDefault(c => c.EmployeeID == employeeId);

            _employeeRepository.Remove(newEmployee);
            _employeeRepository.SaveChanges();
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

        private EmployeeDto ConvertToDto(Employee e)
        {
            return new EmployeeDto
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                CountryID = e.CountryID,
                Shift = StringToShift(e.Shift),
                HiringDate = e.HiringDate,
                HourlyWage = e.HourlyWage
            };
        }
        private Employee CreateFromDto(EmployeeDto e)
        {
            return new Employee() 
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                CountryID = e.CountryID,
                Shift = ShiftToString(e.Shift),
                HiringDate = e.HiringDate,
                HourlyWage = e.HourlyWage
            };
        }

    }
}
