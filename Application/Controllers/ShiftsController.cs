using Services;
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
            var employeeService = new EmployeeService();
            
            var list = employeeService.GetEmployeeShift(employeeService.StringToShift(shift));
            HttpContext.Application["EditId"] = -1;

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

            HttpContext.Application["EditId"] = employee.EmployeeID;

            var employeeService = new EmployeeService();

            var list = employeeService.GetEmployeeShift(shift);

            return View("SelectShift", list);
        }

        [HttpPost]
        public ActionResult AddRow(int employeeId, int hours, int minutes, Shifts shift)
        {
            var workingDayServices = new WorkingDayService();
            
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                                             DateTime.Now.Day, hours, minutes, 0 );

            var workingDayDto = new WorkingDayDto()
            {
                EmployeeID = employeeId,
                TimeIn = dateTime
            };

            workingDayServices.Create(workingDayDto);

            ViewBag.JustCreated = true;

            var employeeService = new EmployeeService();

            var list = employeeService.GetEmployeeShift(shift);

            return View("SelectShift", list);
        }

        [HttpPost]
        public ActionResult UpdateRow(int employeeId, int hours, int minutes, Shifts shift)
        {
            var workingDayServices = new WorkingDayService();
            
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                                             DateTime.Now.Day, hours, minutes, 0);

            var hoursWorked = dateTime.Hour - Decimal.Parse(Convert.ToString(Session["TimeIn"]));

            if(hoursWorked <= 0)
            {
                hoursWorked = 0.1m;
            }


            var workingDayDto = new WorkingDayDto
            {
                WorkingDayID = Int32.Parse(Convert.ToString(Session["WorkingDayID"])),
                EmployeeID = employeeId,
                TimeOut = dateTime,
                HoursWorked = hoursWorked
            };

            workingDayServices.Update(workingDayDto);

            var employeeService = new EmployeeService();

            var list = employeeService.GetEmployeeShift(shift);

            return View("SelectShift", list);
        }
        
    }
}