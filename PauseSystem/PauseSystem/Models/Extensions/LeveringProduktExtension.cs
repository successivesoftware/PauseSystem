using PauseSystem.Helpers;
using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models.Extensions
{
    public static class LeveringProduktExtension
    {
        public static IList<CustomerDeliveryAdresses> GetDeliveries(this IRepository<LeveringsProdukt> repository, UnitOfWork unitOfWork,
         DateTime startDate, DateTime endDate, int kundeId)
        {
            var finalProdukter = new List<LeveringsProdukt>();
            var deliveries = new List<CustomerDeliveryAdresses>();
            startDate = startDate.Date;
            endDate = endDate.Date;

            var qleveringer = unitOfWork.Repository<TurLevering>().AsQuerable().Where(l => l.Ture.Dato >= startDate.Date && l.Ture.Dato <= endDate.Date && l.KundeId == kundeId);
            var leveringMonday = unitOfWork.Repository<TurLevering>().AsQuerable().Max(k => k.Ture.Dato).GetNextMonday().Date;
            var leveringDateMax = leveringMonday > startDate ? leveringMonday : startDate;
            if (qleveringer.Any())
            {
                if (qleveringer.Any(l => l.Ture.Dato > leveringDateMax))
                    leveringDateMax = qleveringer.Max(l => l.Ture.Dato);
                finalProdukter.AddRange(qleveringer.SelectMany(l => l.LeveringProdukts));
            }
            if (qleveringer.Any(l => l.Ture.Dato > leveringDateMax))
                leveringDateMax = qleveringer.Max(l => l.Ture.Dato);

            var maxDate = TimeTool.GetDate(DateTime.Now.Year, TimeTool.GetWeekNumber(leveringDateMax), (int)DayOfWeek.Monday).Date;
            maxDate = maxDate > startDate ? maxDate : startDate;
            if (leveringDateMax > maxDate.Date)
                maxDate = leveringDateMax.Date;

            if (maxDate.Date < endDate.Date)
            {
                List<Abonnementer> abonnementer = unitOfWork.Repository<Abonnementer>().AsQuerable().Where(t => t.Kunde.Id == kundeId).ToList();
                foreach (var tmpway in TimeTool.GetWeekAndYears(maxDate, endDate))
                {
                    var ableveringer = abonnementer.GetLeveringerForService(tmpway.Year, tmpway.Week, unitOfWork.Repository<ProductCustomerSpecialPrice>().AsQuerable());
                    ableveringer.All(abl =>
                    {
                        abl.Ture = new Ture()
                        {
                            TurId = abl.Ture.TurId,
                            Week = abl.Ture.Week,
                            Year = abl.Ture.Year,
                            DayOfWeek = abl.Ture.DayOfWeek,
                            Dato = TimeTool.GetDate(abl.Ture.Year, abl.Ture.Week, (int)abl.Ture.DayOfWeek)
                        };
                        return true;
                    });

                    finalProdukter.AddRange(ableveringer.SelectMany(l => l.LeveringProdukts));
                }
            }

            var produkter = finalProdukter.OrderBy(p => p.TurLevering.Ture.Dato).ThenBy(p => p.Produkt.Navn).ToList();
            foreach (var levering in produkter.Where(p => p.TurLevering.Ture.Dato.Date >= startDate.Date && p.TurLevering.Ture.Dato <= endDate.Date))
            {

                if (deliveries.Any(m => m.AdressId == levering.TurLevering.AdresseId))
                {
                    if (deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                        .DeliveryWeeks.Any(dw => dw.Week == levering.TurLevering.Ture.Week))
                    {
                        if (deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                            .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                            .DeliverDates.Any(l => l.Date.Date == levering.TurLevering.Ture.Dato.Date))
                        {
                            deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                                .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                                .DeliverDates.First(l => l.Date.Date == levering.TurLevering.Ture.Dato.Date)
                                .Deliveries.Add(CustomerDelivery.CreateInstance(levering));
                        }
                        else
                        {
                            deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                                .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                                .DeliverDates.Add(CustomerDeliverDates.CreateInstance(levering));
                        }
                    }
                    else
                    {
                        deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                            .DeliveryWeeks.Add(CustomerDeliveryWeek.CreateInstance(levering));
                    }
                }
                else
                {
                    deliveries.Add(CustomerDeliveryAdresses.CreateInstance(levering));
                }
            }
            return deliveries.Distinct().ToList();

        }

    }
}