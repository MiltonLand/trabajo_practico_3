using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.Dtos;
using System.Net;

namespace Application.Controllers
{
    public class CountryController : Controller
    {
        public ActionResult Index()
        {
            var services = new CountryService();

            var countries = services.GetAll();
            return View(countries);
        }

        [HttpPost]
        public ActionResult Index(string countryName)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Update(int? countryID, string newCountryName)//CountryDto country)
        {

            var services = new CountryService();

            //using(var services = new CountryService())
            //{
            //para usar esta forma convertir los servicios CountryServices, etc para que hereden de IDisposable (tienen que implementar
            //el método Dispose() por lo menos aunque esté vacío
            //
            //  services.Update(country);
            //
            //}

            //var countryToUpdate = services.Read(country.CountryID);
            //var countryToUpdate = services.Read(newCountryName);

            /*
                var countryToUpdate = services.Read((int)countryID);
                countryToUpdate.CountryName = newCountryName;
                services.Update(countryToUpdate);
            */

            services.Update((int)countryID,newCountryName);

            return View("Index",services.GetAll());
            
        }

        [HttpGet]
        public ActionResult Edit(int? id)//(CountryDto country)
        {

            int? countryID = id;//country.CountryID;

            if (countryID == null)
            {
                //using System.Net;
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var services = new CountryService();

            var countryToUpdate = services.Read((int)countryID);
            if (countryToUpdate == null)
            {
                return HttpNotFound("Lá página solicitada no existe!!!");
            }

            

            //var countryToUpdate = services.Read(country.CountryID);
            //var countryToUpdate = services.Read(countryID);


            return View(countryToUpdate);
        }

        public ActionResult Create()
        {
            return View();// new CountryService().GetAll());
        }

        [HttpPost]
        public ActionResult Creation(string Name)
        {
            var countryService = new CountryService();

            countryService.Create(Name);

            return View("Index", countryService.GetAll());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var countryService = new CountryService();

            if(!countryService.CheckHasEmployees((int)id))
            {
                
                return View(new CountryService().Read((int)id));
            }
            
            return View("CannotDelete", new CountryService().Read((int)id));
        }

        public ActionResult CannotDelete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            return View(new CountryService().Read((int)id));
        }

        [HttpPost]
        public ActionResult Deletion(int id)
        {
            var countryService = new CountryService();

            countryService.Delete(id);

            return View("Index", countryService.GetAll());
        }
    }
}