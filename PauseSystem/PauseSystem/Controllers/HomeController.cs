using PauseSystem.Models;
using PauseSystem.Models.Entity;
using PauseSystem.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PauseSystem.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        IRepository<LeveringsProdukt> LeveringProduktRepository = null;
        IRepository<Abonnementer> AbonnementerRepository = null;

        public HomeController()
        {
            LeveringProduktRepository = unitOfWork.Repository<LeveringsProdukt>();
            AbonnementerRepository = unitOfWork.Repository<Abonnementer>();
        }


        [AllowAnonymous]
        public ActionResult Index()
        {

            if (PauseSecurity.IsAuthenticated)
            {
                var model = new LeveringModel() { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(10) };
                if (PauseSecurity.IsInRole(RoleTypes.Customer))
                {
                    model.KundeId = PauseSecurity.GetUserId();
                    model.CustomerDeliveryAdresses = GetCustomerDeliveryAdresses(model.KundeId, model.StartDate, model.EndDate);
                }
                return View("Levering", model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(LeveringModel model)
        {
            // Change KundeId if user is customer
            if (PauseSecurity.IsInRole(RoleTypes.Customer))
            {
                model.KundeId = PauseSecurity.GetUserId();
            }
            if (model.KundeId <= 0)
            {
                ModelState.AddModelError("KundeName", "Kunde eksisterer ikke.");
            }
            else if (model.EndDate < model.StartDate)
            {
                ModelState.AddModelError("EndDate", "Slutdato bør ikke være mindre Startdato.");
            }
            if (!ModelState.IsValid)
            {
                return View("Levering", model);
            }
           
            model.CustomerDeliveryAdresses =  GetCustomerDeliveryAdresses(model.KundeId, model.StartDate, model.EndDate);
            return View("Levering", model);
        }


        public ActionResult Subscriptions(int? kundeId)
        {
            if(PauseSecurity.IsInRole(RoleTypes.Customer))
                kundeId = PauseSecurity.GetUserId(); 
            if(kundeId.HasValue)
                return View(GetCustomerSubscriptions(kundeId.Value));
            else
                return View(new List<Abonnementer>());
        }

        #region Private Methods
     
        private string GetProduktSearchOutputHtml(string name, double price, string icon)
        {
            return String.Format("<div><img src='{0}' style='max-height:50px;' /> <strong> {1} </strong> <label class='label label-warning' style='margin:left:10px;'> {2} <label> </div>",
                        icon, name, price);
        }

        private IList<CustomerDeliveryAdresses> GetCustomerDeliveryAdresses(int kundeId, DateTime startDate, DateTime endDate)
        {
            ViewBag.StartDate = startDate.ToDateString();
            ViewBag.EndDate = endDate.ToDateString();
            return LeveringProduktRepository.GetDeliveries(unitOfWork, startDate, endDate, kundeId);
        }


        /// <summary>
        /// returns customer future subscriptions
        /// </summary>
        /// <param name="kundeId"></param>
        /// <returns></returns>
        private IList<Abonnementer> GetCustomerSubscriptions(int kundeId)
        {
            return AbonnementerRepository.AsQuerable().Where(t => t.Kunde.Id == kundeId).ToList();
        }


        #endregion


        #region AjaxMethods

        [HttpGet]
        public JsonResult AjaxGetProdukt(string query)
        {
            var qprodukt = unitOfWork.Repository<Produkt>().AsQuerable()
                .Where(p => p.Active == true && (p.Navn.Contains(query) || p.ProduktNr.ToString().Contains(query)))
                .Take(10)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Navn,
                    Price = x.KostPris,
                    ProduktNr = x.ProduktNr,
                }).ToList()
            .Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ProduktNr = x.ProduktNr,
                HtmlString = GetProduktSearchOutputHtml(x.Name, x.Price, "Images/img1.jpg")
            });
            return this.ToJsonResult(qprodukt.ToList());
        }


        [HttpGet]
        [Authorize(Roles = RoleTypes.Employee)]
        public JsonResult AjaxGetKunder(string query)
        {
            var qprodukt = unitOfWork.Repository<Kunde>().AsQuerable()
                .Where(p => p.Navn.Contains(query) || p.Email.ToString().Contains(query))
                .Take(10)
                .Select(x => new
                {
                    Id = x.Id,
                    DisplayName = x.Navn + " (" + x.Email + ")",
                    Name = x.Navn,
                }).ToList();
            return this.ToJsonResult(qprodukt);
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
        public PartialViewResult AjaxAddProduct(int produktNr)
        {
            var produkt = unitOfWork.Repository<Produkt>().AsQuerable().FirstOrDefault(x => x.ProduktNr == produktNr);
            return PartialView("_UCDelivery", new CustomerDelivery
            {
                Number = 1,
                ProduktNumber = produkt.ProduktNr,
                Produkt = produkt.Navn,
                Id = produkt.Id,
                Pris = produkt.SalgsPris
            });
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

       

        #endregion


        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }

}