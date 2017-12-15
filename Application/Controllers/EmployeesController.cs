using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Services.Dtos;

namespace Application.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult Index()
        {
            var employeeService = new EmployeeService();
            var countryService = new CountryService();

            var tuple = Tuple.Create(employeeService.GetAll(), countryService.GetAll());

            return View(tuple);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Create()
        {
            var countryService = new CountryService();

            return View(countryService.GetAll());
        }

        [HttpPost]
        public ActionResult Creation(string fName, string lName, int countryId, string shift, DateTime hiringDate, decimal hourlyWage)
        {
            var employeeService = new EmployeeService();
            var countryService = new CountryService();

            var country = countryService.Read(countryId);
            var countryName = country.CountryName;

            var employeeDto = new EmployeeDto()
            {
                FirstName = fName,
                LastName = lName,
                Country = countryName,
                Shift = employeeService.StringToShift(shift),
                HiringDate = hiringDate,
                HourlyWage = hourlyWage
            };

            employeeService.Create(employeeDto);
            
            var tuple = Tuple.Create(employeeService.GetAll(), countryService.GetAll());

            return View("Index", tuple);
        }
        
        public ActionResult Delete(int id)
        {
            var employeeService = new EmployeeService();
            var countryService = new CountryService();

            employeeService.Delete(id);

            var tuple = Tuple.Create(employeeService.GetAll(), countryService.GetAll());

            return View("Index", tuple);
        }
    }
}