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

        public HomeController()
        {

        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult GetLeverings()
        {
            int kundeId = 0;
            DateTime startDate = DateTime.Now.AddHours(-100), endDate = DateTime.Now.AddDays(100);


            //if (maxDate.Date < endDate.Date)
            //{
            //    var abonnementer = unitOfWork.Repository<Abonnementer>().AsQuerable().Where(x => x.KundeId == kundeId);
            //    var ways = TimeTool.GetWeekAndYears(maxDate, endDate);

            //    //subusiContext.ProductCustomerSpecialPrices.Load();

            //    foreach (var tmpway in ways)
            //    {
            //        var ableveringer = abonnementer.GetLeveringerForService(tmpway.Year, tmpway.Week, unitOfWork.Repository<ProductCustomerSpecialPrice>().AsQuerable());
            //        ableveringer.All(abl =>
            //        {
            //            abl.Tur = new Ture()
            //            {
            //                TurId = abl.Tur.TurId,
            //                Week = abl.Tur.Week,
            //                Year = abl.Tur.Year,
            //               // UgeDag = abl.Tur.UgeDag,
            //                Dato = TimeTool.GetDate(abl.Tur.Year, abl.Tur.Week, (int)abl.Tur.UgeDag)
            //            };
            //            return true;
            //        });

            //        finalProdukter.AddRange(ableveringer.SelectMany(l => l.Produkter));
            //    }
            //}




            //if (startDate.HasValue)
            //    query = query.Where(x => x.TurLevering.Ture.Dato.Value > startDate);





            //var k = query.Take(20).Select(x => new CustomerDelivery
            //{
            //    Antal = x.Antal,
            //    VareNr = x.ProduktNr,
            //    Beskrivelse = x.Produkt.Navn.ToString(), //.Navn,
            //    Pris = x.SalgsPris,
            //    SampletPris = x.SalgsPris
            //}).ToList();





            var items = unitOfWork.Repository<LeveringsProdukt>().GetDeliveries(unitOfWork,kundeId, startDate,endDate);

            return PartialView("_UCLiverings", items);
        }

        [Authorize(Roles=UserRoleTypes.Customer)]
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