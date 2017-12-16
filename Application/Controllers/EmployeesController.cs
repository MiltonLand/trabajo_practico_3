﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Services;
using Services.Dtos;

namespace Application.Controllers
{
    public class EmployeesController : Controller
    {
        public EmployeesController()
        {
            //Sets formats to english.
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        public ActionResult Index()
        {
            return View(new EmployeeService().GetAll());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return View("Index", new EmployeeService().GetAll());

            var employeeService = new EmployeeService();
            var countryService = new CountryService();
            var employee = employeeService.Read((int)id);

            if (employee == null)
                return View("Index", employeeService.GetAll());

            var tuple = Tuple.Create(employee, countryService.GetAll());

            return View(tuple);
        }

        [HttpPost]
        public ActionResult Edition(int id, string fName, string lName, string country, string shift, DateTime hiringDate, decimal hourlyWage)
        {
            var employeeService = new EmployeeService();

            var employeeDto = employeeService.CreateDto(fName, lName, country, shift, hiringDate, hourlyWage, id);

            employeeService.Update(employeeDto);

            return View("Index", employeeService.GetAll());
        }

        public ActionResult Create()
        {
            return View(new CountryService().GetAll());
        }

        [HttpPost]
        public ActionResult Creation(string fName, string lName, string country, string shift, DateTime hiringDate, decimal hourlyWage)
        {
            var employeeService = new EmployeeService();

            employeeService.Create(fName, lName, country, shift, hiringDate, hourlyWage);

            return View("Index", employeeService.GetAll());
        }

        public ActionResult Delete(int id)
        {
            var employeeService = new EmployeeService();

            return View(employeeService.Read(id));
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            var employeeService = new EmployeeService();

            employeeService.Delete(id);

            return View("Index", employeeService.GetAll());
        }

        public ActionResult Salary(int id)
        {
            var employeeService = new EmployeeService();
            var workingDayService = new WorkingDayService();

            var year = DateTime.Today.Year;
            var month = DateTime.Today.Month;
            
            var workingDaysMonth = workingDayService.GetAllForEmployeeInMonth(id, year, month);

            var tuple = Tuple.Create(employeeService.Read(id), workingDaysMonth);

            var salary = employeeService.Salary(id, year, month);
            ViewBag.Salary = salary;

            return View(tuple);
        }
    }
}