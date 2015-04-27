using PauseSystem.Helpers;
using PauseSystem.Models;
using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PauseSystem.Models;

namespace PauseSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (PauseSecurity.IsAuthenticated)
            {
                return View("Livering", GetDeliveries(DateTime.Now.AddMonths(-1), DateTime.Now));
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue)
                ModelState.AddModelError("StartDate", "StartDate field is required.");
            else if (!endDate.HasValue)
                ModelState.AddModelError("EndDate", "StartDate field is required.");
            else if (CustomDateTime.IsPastDate(endDate.Value))
                ModelState.AddModelError("EndDate", "EndDate should not be past date.");
            else if (endDate.Value < startDate.Value)
                ModelState.AddModelError("EndDate", "EndDate should not be be less StartDate.");
            if (!ModelState.IsValid)
            {
                return View(new List<CustomerDeliveryAdresses>());
            }
            return View(GetDeliveries(startDate.Value, endDate.Value));
        }


        private IList<CustomerDeliveryAdresses> GetDeliveries(DateTime startDate, DateTime endDate)
        {
            ViewBag.StartDate = startDate.ToDateString();
            ViewBag.EndDate = endDate.ToDateString();
            return unitOfWork.Repository<LeveringsProdukt>().GetDeliveries(unitOfWork, startDate, endDate, PauseSecurity.GetUserId());
        }


        [HttpPost]
        public JsonResult AjaxDeleteDelivery(int id)
        {
            // Write the code to delete delivery here

            return this.ToJsonResult(id);
        }

        [HttpPost]
        public ActionResult AjaxDeleteDeliveryWeek(string date)
        {
            // Write the code to delete delivery week here

            return this.ToJsonResult(date);
        }

        [HttpPost]
        public ActionResult AjaxChangeAntalValue(int produktNumber, int value, string mode)
        {
            if (mode == "+")
            {
                value += 1;
                // Write the code to increase Antal value

            }
            else if (value > 0)
            {
                value -= 1;
                // Write the code to decrease Antal value
            }
            return this.Content(value.ToString());
        }

        [HttpPost]
        public JsonResult AjaxSearchProdukt(string q, int limit = 10)
        {
            var query = unitOfWork.Repository<Produkt>().AsQuerable().Where(x => 
                x.Active == true
                &&
                (x.Navn.Contains(q) || x.ProduktNr.ToString().Contains(q))
                //x.Navn.ToLower().Contains(q.ToLower())
            ).Take(limit);
            var result = query.Select(x => new ProduktSearchResult
            {
                Id = x.Id,
                ProduktName = x.Navn,
                Icon = "/Images/img1.jpg",
                Price = x.KostPris,
                ProducktNr = x.ProduktNr
            });

            return this.ToJsonResult(result);
        }

        [HttpPost]
        public PartialViewResult AjaxAddProduct(int producktNr)
        {
            var produkt = unitOfWork.Repository<Produkt>().AsQuerable().FirstOrDefault(x => x.ProduktNr == producktNr);
            return PartialView("_UCDelivery", new CustomerDelivery
            {
                Number = 1,
                ProduktNumber = produkt.ProduktNr,
                Produkt = produkt.Navn,
                Id = produkt.Id,
                Pris = produkt.SalgsPris
            });  
        }
    }
}