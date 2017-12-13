using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace Application.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult Index()
        {
            var employeeService = new EmployeeService();

            return View(employeeService.GetAll());
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
        public ActionResult Creation(string fName, string lName, int countryId, string shift, DateTime hireDate)
        {
            var employeeService = new EmployeeService();

            employeeService.Create(fName, lName, countryId, shift, hireDate);

            return View("Index", employeeService.GetAll());
        }
    }
}