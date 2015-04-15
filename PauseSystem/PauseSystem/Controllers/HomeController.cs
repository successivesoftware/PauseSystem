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


        [AllowAnonymous]
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue)
                startDate = DateTime.Today.AddMonths(-1);
            if (!endDate.HasValue)
                endDate = DateTime.Today.AddMonths(1);

            ViewBag.StartDate = startDate.ToDateString();
            ViewBag.EndDate = endDate.ToDateString();
            return View(GetDeliveries(startDate.Value, endDate.Value));
        }



        private IList<CustomerDeliveryAdresses> GetDeliveries(DateTime startDate, DateTime endDate)
        {
            int? kundeId = PauseSecurity.IsInRole(RoleTypes.Customer) ? PauseSecurity.GetUserId() : (Nullable<int>)null;
            return unitOfWork.Repository<LeveringsProdukt>().GetDeliveries(unitOfWork, startDate, endDate, kundeId);
        }


        //[AcceptVerbs(HttpVerbs.Post)]
        //public PartialViewResult getLeverings(DateTime StartDate, DateTime EndDate)
        //{
        //    int kundeId = PauseSecurity.GetUserId();
        //    DateTime startDate = StartDate;
        //    DateTime endDate = EndDate;
        //    IList<CustomerDelivery> items;
        //    if (User.IsInRole(UserRoleTypes.Employee))
        //    {
        //        items = unitOfWork.Repository<LeveringsProdukt>().GetDeliveries(unitOfWork, startDate, endDate);
        //    }
        //    else
        //    {
        //        items = unitOfWork.Repository<LeveringsProdukt>().GetDeliveriesForCustomer(unitOfWork, kundeId, startDate, endDate);
        //    }
        //    var adresse = unitOfWork.Repository<Adresser>().AsQuerable().Where(x => x.KundeId == kundeId)
        //                                    .Select(x => new { address = x.Adresse + ", " + x.PostNr + ", " + x.City });

        //    foreach (var address in adresse)
        //    {
        //        ViewBag.Adresse = address.address;
        //    }

        //    return PartialView("_UCLiverings2", items);
        //}

        //[ChildActionOnly]
        //public PartialViewResult GetLeverings()
        //{
        //    int kundeId = PauseSecurity.GetUserId();
        //    DateTime startDate = DateTime.Now;
        //    DateTime endDate = DateTime.Now;
        //    IList<CustomerDelivery> items;
        //    if (User.IsInRole(UserRoleTypes.Employee))
        //    {
        //        items = unitOfWork.Repository<LeveringsProdukt>().GetDeliveries(unitOfWork, startDate, endDate);
        //    }
        //    else
        //    {
        //        items = unitOfWork.Repository<LeveringsProdukt>().GetDeliveriesForCustomer(unitOfWork, kundeId, startDate, endDate);
        //    }

        //    //if (maxDate.Date < endDate.Date)
        //    //{
        //    //    var abonnementer = unitOfWork.Repository<Abonnementer>().AsQuerable().Where(x => x.KundeId == kundeId);
        //    //    var ways = TimeTool.GetWeekAndYears(maxDate, endDate);

        //    //    //subusiContext.ProductCustomerSpecialPrices.Load();

        //    //    foreach (var tmpway in ways)
        //    //    {
        //    //        var ableveringer = abonnementer.GetLeveringerForService(tmpway.Year, tmpway.Week, unitOfWork.Repository<ProductCustomerSpecialPrice>().AsQuerable());
        //    //        ableveringer.All(abl =>
        //    //        {
        //    //            abl.Tur = new Ture()
        //    //            {
        //    //                TurId = abl.Tur.TurId,
        //    //                Week = abl.Tur.Week,
        //    //                Year = abl.Tur.Year,
        //    //               // UgeDag = abl.Tur.UgeDag,
        //    //                Dato = TimeTool.GetDate(abl.Tur.Year, abl.Tur.Week, (int)abl.Tur.UgeDag)
        //    //            };
        //    //            return true;
        //    //        });

        //    //        finalProdukter.AddRange(ableveringer.SelectMany(l => l.Produkter));
        //    //    }
        //    //}




        //    //if (startDate.HasValue)
        //    //    query = query.Where(x => x.TurLevering.Ture.Dato.Value > startDate);





        //    //var k = query.Take(20).Select(x => new CustomerDelivery
        //    //{
        //    //    Antal = x.Antal,
        //    //    VareNr = x.ProduktNr,
        //    //    Beskrivelse = x.Produkt.Navn.ToString(), //.Navn,
        //    //    Pris = x.SalgsPris,
        //    //    SampletPris = x.SalgsPris
        //    //}).ToList();


        //    var adresse = unitOfWork.Repository<Adresser>().AsQuerable().Where(x => x.KundeId == kundeId)
        //                                    .Select(x => new { address = x.Adresse + ", " + x.PostNr + ", " + x.City });

        //    foreach (var address in adresse)
        //    {
        //        ViewBag.Adresse = address.address;
        //    }

        //    return PartialView("_UCLiverings", items);
        //}





        [Authorize(Roles = RoleTypes.Customer)]
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