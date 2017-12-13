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
            return View();
        }
    }
}