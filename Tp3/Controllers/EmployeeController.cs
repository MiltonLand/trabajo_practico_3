using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Services;
using System.Net;
using Entities;

namespace Tp3.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(EmployeeService.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(CountryService.GetAll(), "CountryID", "CountryName");
            ViewBag.TurnID = new SelectList(TurnService.GetAll(), "TurnID", "Description");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FirstName,LastName,CountryID,TurnID,HireDate")] Employees employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeService.Add(employee);
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(CountryService.GetAll(), "CountryID", "CountryName", employee.CountryID);
            ViewBag.TurnID = new SelectList(TurnService.GetAll(), "TurnID", "Description", employee.TurnID);
            return View(employee);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employee = EmployeeService.FindID(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
    }

}