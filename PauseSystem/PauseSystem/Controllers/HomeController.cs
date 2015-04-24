using PauseSystem.Helpers;
using PauseSystem.Models;
using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PauseSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        IRepository<Produkt> produktRepository;

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (PauseSecurity.IsAuthenticated)
            {
                return View("Livering",GetDeliveries( DateTime.Now.AddMonths(-1), DateTime.Now));
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
        public ActionResult AjaxUpdateAntal(int produktNumber, int operation)
        {
            //operation = 0 to decrease & 1 to increase
            return this.ToJsonResult(produktNumber);
        }
        
        [HttpPost]
        public JsonResult GetProductName(string filterKey, int limit = 10)
        {
            produktRepository = unitOfWork.Repository<Produkt>();
            return Json(produktRepository.AsQuerable().Where(x => x.Navn.ToLower().Contains(filterKey.ToLower())).Select(x => new
            {
                img = "/Content/Images/loading.gif",
                price = x.KostPris,
                text = x.Navn,
                value = x.Id,
                varenr = x.ProduktNr,
                sprice = x.SalgsPris
            }).Take(limit).ToArray(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AjaxAddNewProductRow(int id)
        {
            return this.ToJsonResult(id);
        }

        //[Authorize(Roles = RoleTypes.Customer)]
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";
        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";
        //    return View();
        //}
    }
}