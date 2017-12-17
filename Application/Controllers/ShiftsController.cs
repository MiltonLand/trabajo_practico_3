﻿using Services;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Services.Dtos.EmployeeDto;

namespace Application.Controllers
{
    public class ShiftsController : Controller
    {
        public ActionResult SelectShift()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult GetEmployees(String shift)
        {

            ViewBag.SelectedShift = shift;
            var employeeService = new EmployeeService();
            
            var list = employeeService.GetEmployeeShift(employeeService.StringToShift(shift));

            return View("SelectShift", list);
        }
        
        public ActionResult AddTime(EmployeeWorkDay employee, Shifts shift)
        {
            ViewBag.NewRow = null;
            ViewBag.TimeOut = false;
            Session["EmployeeID"] = employee.EmployeeID;
            Session["WorkingDayID"] = employee.WorkingDayID;
            Session["TimeIn"] = employee.TimeIn.GetValueOrDefault().Hour;
            
            var workingDayServices = new WorkingDayService();
            
            if (employee.TimeIn == null)
            {                             
                ViewBag.NewRow = true;
            }
            else if(employee.TimeOut == null)
            {
                ViewBag.NewRow = false;
            }
            else
            {
                ViewBag.TimeOut = true;
            }

            ViewBag.EditId = employee.EmployeeID;

            var employeeService = new EmployeeService();

            var list = employeeService.GetEmployeeShift(shift);

            return View("SelectShift", list);
        }

        [HttpPost]
        public ActionResult AddRow(string hour)
        {
            var workingDayServices = new WorkingDayService();

            int hourP = Int32.Parse(hour);
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourP, 0, 0 );
            


            var workingDayDto = new WorkingDayDto
            {
                EmployeeID = Int32.Parse(Convert.ToString(Session["EmployeeID"])),
                TimeIn = dateTime
            };

            workingDayServices.Create(workingDayDto);

            return View("SelectShift");
        }

        [HttpPost]
        public ActionResult UpdateRow(string hour)
        {
            var workingDayServices = new WorkingDayService();

            int hourP = Int32.Parse(hour);
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourP, 0, 0);

            var hourWorked = dateTime.Hour - Decimal.Parse(Convert.ToString(Session["TimeIn"]));

            if(hourWorked <= 0)
            {
                hourWorked = 0.1m;
            }


            var workingDayDto = new WorkingDayDto
            {
                WorkingDayID = Int32.Parse(Convert.ToString(Session["WorkingDayID"])),
                EmployeeID = Int32.Parse(Convert.ToString(Session["EmployeeID"])),
                TimeOut = dateTime,
                HoursWorked = hourWorked
            };

            workingDayServices.Update(workingDayDto);

            return View("SelectShift");
        }
        
    }
}