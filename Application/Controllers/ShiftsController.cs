using Services;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [HttpPost]
        public ActionResult AddTime(int? ddl)
        {
            ViewBag.NewRow = null;
            ViewBag.TimeOut = false;
            Session["EmployeeID"] = ddl;

            var workingDayServices = new WorkingDayService();
            var workingDay = workingDayServices.GetWorkingDayById(ddl);


            if (workingDay != null)
            {
                if (workingDay.TimeOut != null)
                {
                    ViewBag.TimeOut = true;
                }
                               
                ViewBag.NewRow = true;
                Session["WorkingDayID"] = workingDay.WorkingDayID;
                Session["TimeIn"] = workingDay.TimeIn.Hour;
            }
            else
            {
                ViewBag.NewRow = false;
            }

            return View("SelectShift");
        }

        [HttpPost]
        public ActionResult AddRow(string hour)
        {
            var workingDayServices = new WorkingDayService();

            int hourP = Int32.Parse(hour);
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourP, 0, 0 );
            
            dateTime.AddHours((double)Convert.ToInt32(hour));
            dateTime.AddYears(DateTime.Now.Year);
            dateTime.AddMonths(DateTime.Now.Month);
            dateTime.AddDays(DateTime.Now.Day);

            var workingDayDto = new WorkingDayDto
            {
                EmployeeID = Int32.Parse(Convert.ToString(Session["EmployeeID"])),
                TimeIn = dateTime
            };

            workingDayServices.Save(workingDayDto);

            return View("SelectShift");
        }

        [HttpPost]
        public ActionResult UpdateRow(string hour)
        {
            var workingDayServices = new WorkingDayService();

            int hourP = Int32.Parse(hour);
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourP, 0, 0);

            dateTime.AddHours((double)Convert.ToInt32(hour));
            dateTime.AddYears(DateTime.Now.Year);
            dateTime.AddMonths(DateTime.Now.Month);
            dateTime.AddDays(DateTime.Now.Day);

            var workingDayDto = new WorkingDayDto
            {
                WorkingDayID = Int32.Parse(Convert.ToString(Session["WorkingDayID"])),
                EmployeeID = Int32.Parse(Convert.ToString(Session["EmployeeID"])),
                TimeOut = dateTime,
                WorkedHours = dateTime.Hour - Int32.Parse(Convert.ToString(Session["TimeIn"]))
            };

            workingDayServices.Update(workingDayDto);

            return View("SelectShift");
        }
        
    }
}