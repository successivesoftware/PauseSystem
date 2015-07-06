using PauseSystem.Helpers;
using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models.Extensions
{
    //public static class PreAbonnementExtension
    //{
    //    public static IList<CustomerDeliveryAdresses> GetDeliveries(this IRepository<PreAbonnement> repository, UnitOfWork unitOfWork,
    //     DateTime startDate, DateTime endDate, int kundeId)
    //    {
    //        var finalProdukter = new List<LeveringsProdukt>();
    //        var deliveries = new List<CustomerDeliveryAdresses>();
    //        startDate = startDate.Date;
    //        endDate = endDate.Date;
    //        var qPreAbonnement = unitOfWork.Repository<PreAbonnement>().AsQuerable().Where(l => l.StartDate >= startDate && l.EndDate <= endDate && l.Adresser.KundeId == kundeId);
    //        var preAbonnementMonday = unitOfWork.Repository<PreAbonnement>().AsQuerable().Max(k => k.StartDate).GetNextMonday().Date;
    //        var preAbonnementDateMax = preAbonnementMonday > startDate ? preAbonnementMonday : startDate;
    //         if(qPreAbonnement.Any())
    //        {
    //            if(qPreAbonnement.Any(l => l.StartDate > preAbonnementDateMax))
    //                preAbonnementDateMax = qPreAbonnement.Max(l => l.StartDate);
    //            finalProdukter.AddRange(qPreAbonnement.SelectMany(l => l.TurLevering.LeveringProdukts));
    //        }

    //         if (qPreAbonnement.Any(l => l.StartDate > preAbonnementDateMax))
    //             preAbonnementDateMax = qPreAbonnement.Max(l => l.StartDate);

    //         var maxDate = TimeTool.GetDate(DateTime.Now.Year, TimeTool.GetWeekNumber(preAbonnementDateMax), (int)DayOfWeek.Monday).Date;
    //         maxDate = maxDate > startDate ? maxDate : startDate;
    //         if (preAbonnementDateMax > maxDate.Date)
    //             maxDate = preAbonnementDateMax.Date;
    //         if (maxDate.Date < endDate.Date)
    //         {
    //             List<Abonnementer> abonnementer = unitOfWork.Repository<Abonnementer>().AsQuerable().Where(t => t.Kunde.Id == kundeId).ToList();
    //             foreach (var tmpway in TimeTool.GetWeekAndYears(maxDate, endDate))
    //             {
    //                 var ableveringer = abonnementer.GetLeveringerForService(tmpway.Year, tmpway.Week, unitOfWork.Repository<ProductCustomerSpecialPrice>().AsQuerable());
    //                 ableveringer.All(abl =>
    //                 {
    //                     abl.Ture = new Ture()
    //                     {
    //                         TurId = abl.Ture.TurId,
    //                         Week = abl.Ture.Week,
    //                         Year = abl.Ture.Year,
    //                         DayOfWeek = abl.Ture.DayOfWeek,
    //                         Dato = TimeTool.GetDate(abl.Ture.Year, abl.Ture.Week, (int)abl.Ture.DayOfWeek)
    //                     };
    //                     return true;
    //                 });

    //                 finalProdukter.AddRange(ableveringer.SelectMany(l => l.LeveringProdukts));

    //             }
    //         }

    //    }
    //}
}