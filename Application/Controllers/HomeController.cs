using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var services = new CountryService();

            services.Create("Argentina");
            var exists = services.countryAlreadyExists("Argentina");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}