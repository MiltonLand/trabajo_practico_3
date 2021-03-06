﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace Application.Controllers
{
    public class SalaryController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Employees");

            var employeeService = new EmployeeService();

            return View(employeeService.Read((int)id));
        }

        [HttpPost]
        public ActionResult Calculate(int id, int year, int month)
        {
            ViewBag.Year = year;
            ViewBag.Month = month;

            var employeeService = new EmployeeService();
            var workingDayService = new WorkingDayService();

            var workingDaysInMonth = workingDayService.GetAllForEmployeeInMonth(id, year, month);

            var tuple = Tuple.Create(employeeService.Read(id), workingDaysInMonth);

            var salary = employeeService.Salary(id, year, month);
            ViewBag.Salary = salary;

            return View("Show", tuple);
        }

        public ActionResult Show()
        {
            return View();
        }
    }
}