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
        IRepository<PreAbonnementProdukt> PreAbonnementRepositry = null;

        public HomeController()
        {
            LeveringProduktRepository = unitOfWork.Repository<LeveringsProdukt>();
            AbonnementerRepository = unitOfWork.Repository<Abonnementer>();
            PreAbonnementRepositry = unitOfWork.Repository<PreAbonnementProdukt>();
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

            model.CustomerDeliveryAdresses = GetCustomerDeliveryAdresses(model.KundeId, model.StartDate, model.EndDate);
            return View("Levering", model);
        }


        public ActionResult Subscriptions(int? kundeId)
        {
            if (PauseSecurity.IsInRole(RoleTypes.Customer))
                kundeId = PauseSecurity.GetUserId();
            if (kundeId.HasValue)
                return View(GetCustomerSubscriptions(kundeId.Value));
            else
                return View(new List<Abonnementer>());
        }

        public ActionResult PreAbonnement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PreAbonnement(PreAbonnementProdukt model)
        {
            if (!ModelState.IsValid)
            {
                return View("PreAbonnement", model);
            }
            if (model.StartDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("StartDate", "Start Dato kan ikke være mindre end dags dato");
            }
            if (model.EndDate < model.StartDate && model.EndDate != null)
            {
                ModelState.AddModelError("EndDate", "Slutdato bør ikke være mindre Startdato.");
            }
            model.CreatedBy = User.Identity.Name;
            model.CreatedAt = DateTime.Now;
            PreAbonnementRepositry.Insert(model);
            unitOfWork.Commit();
            return View();
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
            var result = LeveringProduktRepository.GetDeliveries(unitOfWork, startDate, endDate, kundeId);
            foreach (var res in result)
            {
                // Get Data for addressId
                var preabonnements = PreAbonnementRepositry.AsQuerable().Where(x => x.AddressId == res.AdressId);
                foreach (var preabonnement in preabonnements)
                {
                    res.DeliveryWeeks.Add(CustomerDeliveryWeek.CreateInstance(preabonnement));

                }

            }
            return result;
            //IList<CustomerDeliveryAdresses> result2 = new List<CustomerDeliveryAdresses>();
            //var preabonnements = new List<PreAbonnement>(); // list
            //preabonnements = PreAbonnementRepositry.AsQuerable().Where(t => t.Adresser.KundeId == kundeId || t.StartDate >= startDate || t.EndDate <= endDate).ToList();
            //foreach (var preabonnement in preabonnements)
            //    result2.Add(CustomerDeliveryAdresses.CreateInstance(preabonnement));
            //return result1.Union(result2).ToList();
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

        /// <summary>
        /// Insert PreAbonnementProdukt in Abonnementer
        /// </summary>
        /// <param name="PreAbonnementId"></param>
        /// <returns></returns>
        private void UpdateAbonnemnt(int PreAbonnementId)
        {
            var obj = PreAbonnementRepositry.GetById(PreAbonnementId);

            var details = new Abonnementer
            {
                Ugedag = (DayOfWeek)obj.DayOfWeek,
                RuteIndex = obj.TurLevering.Zindex,
                LeveringsAdresseId = obj.AddressId,
                KundeId = obj.TurLevering.KundeId,
                KundeNr = obj.Adresser.KundeNr,
                StartDato = obj.StartDate,
                SlutDato = obj.EndDate,
                Antal = obj.Antal,
                ProduktNr = obj.ProduktNr,
                Interval = obj.Interval,
                CreatedDate = obj.CreatedAt,
                PrintPakkeList = (bool)obj.TurLevering.PrintPakkeListe
            };
            AbonnementerRepository.Update(details);
            unitOfWork.Commit();
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
                    ProduktNr = x.ProduktNr
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


        /// <summary>
        ///  Change the antal value
        /// </summary>
        /// <param name="produktNumber"></param>
        /// <param name="value"></param>
        /// <param name="mode"></param>
        /// <param name="tempAbonnement"></param>
        /// <param name="PreAbonnementId">Pre Abonement Id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxChangeAntalValue(int produktNumber, int value, string mode, int tempAbonnement, int PreAbonnementId)
        {
            if (tempAbonnement == 1)
            {
                var obj = PreAbonnementRepositry.GetById(PreAbonnementId);
                if (mode == "+")
                {
                    obj.Antal += 1;
                    // Write the code to increase Antal value
                }
                else if (value > 0)
                {
                    obj.Antal -= 1;
                    // Write the code to decrease Antal value
                }
                PreAbonnementRepositry.Update(obj);
                unitOfWork.Commit();
                return this.Content(obj.Antal.ToString());
            }
            else
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
                Id = produkt.Id
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

        [HttpGet]
        public JsonResult AjaxGetProduktForPreAbonnement(string query)
        {
            var productName = unitOfWork.Repository<Produkt>().AsQuerable()
               .Where(p => p.Navn.Contains(query)).Take(10).Select(x => new
               {
                   ProduktNr = x.ProduktNr,
                   DisplayProdukt = x.Navn,
                   Name = x.Navn,
                   Id = x.Id
               }).ToList();
            return this.ToJsonResult(productName);
        }

        [HttpGet]
        public JsonResult AjaxGetAdresse(string query)
        {
            var adress = unitOfWork.Repository<Adresser>().AsQuerable()
                .Where(p => p.Adresse.Contains(query)).Take(10).Select(x => new

                {
                    Id = x.Id,
                    DisplayAdresse = x.Adresse,
                    Adresse = x.Adresse
                }).ToList();
            return this.ToJsonResult(adress);
        }
        #endregion


        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }

}