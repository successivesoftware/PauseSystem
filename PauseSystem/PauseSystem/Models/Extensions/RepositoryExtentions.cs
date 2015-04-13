using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PauseSystem.Helpers;

namespace PauseSystem.Models.Entity
{
    public static class RepositoryExtentions
    {
        public static IList<CustomerDelivery> GetDeliveries(this IRepository<LeveringsProdukt> repository, UnitOfWork unitOfWork, int kundeId, DateTime startDate, DateTime endDate)
        {
            var finalProdukter = new List<LeveringsProdukt>();
            var qLeveringsProdukt = repository.AsQuerable();
            qLeveringsProdukt = qLeveringsProdukt.Where(x => x.TurLevering.Ture.Dato >= startDate && x.TurLevering.Ture.Dato <= endDate && x.TurLevering.KundeId == kundeId);

            return qLeveringsProdukt.Take(20).Select(x => new CustomerDelivery
            {
                Antal = x.Antal,
                VareNr = x.ProduktNr,
                Beskrivelse = x.Produkt.Navn.ToString(), //.Navn,
                Pris = x.SalgsPris,
                SampletPris = x.SalgsPris
            }).ToList();



            //int kundeId = 0;
            //DateTime startDate = DateTime.Now, endDate = DateTime.Now;

            //var finalProdukter = new List<LeveringsProdukt>();
            //var qLeveringsProdukt = unitOfWork.Repository<LeveringsProdukt>().AsQuerable()
            //    .Where(x => x.TurLevering.Ture.Dato >= startDate && x.TurLevering.Ture.Dato <= endDate && x.TurLevering.KundeId == kundeId);

            //var leveringer = qLeveringsProdukt.ToList();
            //var week = TimeTool.GetWeekNumber(DateTime.Now);
            //var leveringsDate = TimeTool.GetNextMonday(unitOfWork.Repository<TurLevering>().AsQuerable().Max(k => k.Ture.Dato).Value);
            //var leveringsDateMax = leveringsDate.Date > startDate.Date ? leveringsDate.Date : startDate.Date;
            //if (leveringer.Count > 0)
            //{
            //    if (leveringer.Any(l => l.TurLevering.Ture.Dato.Value.Date > leveringsDateMax.Date))
            //        leveringsDateMax = leveringer.Max(l => l.TurLevering.Ture.Dato.Value.Date);
            //    finalProdukter.AddRange(leveringer);
            //}

            //if (leveringer.Any(l => l.TurLevering.Ture.Dato.Value.Date > leveringsDateMax.Date))
            //    leveringsDateMax = leveringer.Max(l => l.TurLevering.Ture.Dato.Value.Date);
            //int abbWeek = TimeTool.GetWeekNumber(leveringsDateMax);
            //var maxDate = TimeTool.GetDate(DateTime.Now.Year, abbWeek, (int)DayOfWeek.Monday);
            //maxDate = maxDate.Date > startDate.Date ? maxDate.Date : startDate.Date;
            //if (leveringsDateMax.Date > maxDate.Date)
            //    maxDate = leveringsDateMax.Date;


        }


        //public static IEnumerable<TurLevering> GetLeveringerForService (this IEnumerable<Abonnementer> abonnementer,
        //  int year, int week, IQueryable<ProductCustomerSpecialPrice> priser)
        //{
        //    var kundeLeveringer = new List<TurLevering>();

        //    foreach (Abonnementer abonnement in abonnementer)
        //    {
        //        DateTime leveringsDato = TimeTool.GetDate(year, week, (int)abonnement.Ugedag);
        //        if (abonnement.AbonnementProdukts.Any(ap => ap.IsActive(leveringsDato)
        //            && !ap.OnPause(leveringsDato))
        //            || abonnement.AbonnementProdukts.Any(ap => ap.IsInIntervalWeek(leveringsDato, week))
        //            || abonnement.AbonnementProdukts.Any(ap => ap.IsIntervalOther(abonnement, leveringsDato, week, year)))
        //        {
        //            var levering = new TurLevering()
        //            {
        //                Adresser = abonnement.LeveringsAdresser,
        //                AdresseId = abonnement.LeveringsAdresseId.Value,
        //                Zindex = abonnement.RuteIndex.Value,
        //                Kunde = abonnement.Kunde,
        //                KundeId = abonnement.KundeId.Value,
        //                LeveringsTid = leveringsDato.AddDays(-1),
        //                Id = abonnement.Id,
        //                Ture = new Ture() { Week = week, Year = year, TurId = abonnement.AbonnementRute.RuteId }
        //            };

        //            if (abonnement.PrintPakkeList)
        //                levering.PrintPakkeListe = true;
        //            if (abonnement.PrintPakkeDato.HasValue && leveringsDato.Date == abonnement.PrintPakkeDato.Value.Date)
        //                levering.PrintPakkeListe = true;
        //            foreach (var abonnementProdukt in abonnement.AbonnementProdukts)
        //            {
        //                if (abonnementProdukt.IsActive(leveringsDato) && !abonnementProdukt.OnPause(leveringsDato))
        //                {
        //                    if (abonnementProdukt.IsInIntervalWeek(leveringsDato, week))
        //                    {
        //                        var lp = new LeveringsProdukt()
        //                        {
        //                            KundeLevering = levering,
        //                            ProduktNr = abonnementProdukt.ProduktNr,
        //                            Produkt = abonnementProdukt.Produkt,
        //                            Antal = abonnementProdukt.Antal,
        //                            Id = abonnementProdukt.Id,
        //                            GrossistPris = abonnementProdukt.Produkt.GrossistPris,
        //                            Kg = abonnementProdukt.Produkt.Kg,
        //                            KostPris = abonnementProdukt.Produkt.KostPris,
        //                            PrintLabel = abonnementProdukt.PrintLabel,
        //                            Provision = abonnementProdukt.Produkt.Provision,
        //                            SalgsPris = abonnementProdukt.Produkt.SalgsPris
        //                        };
        //                        if (priser.Any(pc => pc.CustomerId == levering.KundeId && pc.ProductNr == abonnementProdukt.ProduktNr
        //                            && pc.FromDate <= leveringsDato && pc.ToDate >= leveringsDato))
        //                        {
        //                            foreach (var pcsp in priser.Where(pc => pc.CustomerId == levering.KundeId && pc.ProductNr ==
        //                                abonnementProdukt.ProduktNr && pc.FromDate <= leveringsDato && pc.ToDate >= leveringsDato)
        //                                .OrderByDescending(p => p.Antal))
        //                            {
        //                                if (abonnementProdukt.Antal >= pcsp.Antal)
        //                                {
        //                                    lp.SalgsPris = pcsp.Pris;
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                        if (levering.Produkter.All(p => p.Produkt.ProduktNr != lp.Produkt.ProduktNr))
        //                            levering.Produkter.Add(lp);
        //                        else
        //                            levering.Produkter.First(p => p.Produkt.ProduktNr == lp.Produkt.ProduktNr).Antal +=
        //                                lp.Antal;
        //                    }
        //                    else if (abonnementProdukt.IsIntervalOther(abonnement, leveringsDato, week, year))
        //                    {
        //                        var lp = new LeveringsProdukt()
        //                        {
        //                            KundeLevering = levering,
        //                            ProduktNr = abonnementProdukt.ProduktNr,
        //                            Produkt = abonnementProdukt.Produkt,
        //                            Antal = abonnementProdukt.Antal,
        //                            Id = abonnementProdukt.Id,
        //                            GrossistPris = abonnementProdukt.Produkt.GrossistPris,
        //                            Kg = abonnementProdukt.Produkt.Kg,
        //                            KostPris = abonnementProdukt.Produkt.KostPris,
        //                            PrintLabel = abonnementProdukt.PrintLabel
        //                            ,
        //                            Provision = abonnementProdukt.Produkt.Provision,
        //                            SalgsPris = abonnementProdukt.Produkt.SalgsPris
        //                        };
        //                        if (priser.Any(pc => pc.CustomerId == levering.KundeId && pc.ProductNr == abonnementProdukt.ProduktNr
        //                            && pc.FromDate <= leveringsDato && pc.ToDate >= leveringsDato))
        //                        {
        //                            foreach (var pcsp in priser.Where(pc => pc.CustomerId == levering.KundeId && pc.ProductNr ==
        //                                abonnementProdukt.ProduktNr && pc.FromDate <= leveringsDato && pc.ToDate >= leveringsDato)
        //                                .OrderByDescending(p => p.Antal))
        //                            {
        //                                if (abonnementProdukt.Antal >= pcsp.Antal)
        //                                {
        //                                    lp.SalgsPris = pcsp.Pris;
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                        if (levering.Produkter.All(p => p.Produkt.ProduktNr != lp.Produkt.ProduktNr))
        //                            levering.Produkter.Add(lp);
        //                        else
        //                            levering.Produkter.First(p => p.Produkt.ProduktNr == lp.Produkt.ProduktNr).Antal +=
        //                                lp.Antal;
        //                    }
        //                }
        //            }
        //            if (levering.Produkter.Count > 0)
        //                if (levering.Adresse != null && levering.Adresse.X.HasValue && levering.Adresse.Y.HasValue)
        //                    kundeLeveringer.Add(levering);
        //        }

        //    }
        //    return kundeLeveringer;
        //}

        //private static string GetMd5(string TextString)
        //{
        //    MD5 md5 = MD5.Create();
        //    byte[] inputBuffer = System.Text.Encoding.ASCII.GetBytes(TextString);
        //    byte[] outputBuffer = md5.ComputeHash(inputBuffer);

        //    var builder = new StringBuilder(outputBuffer.Length);
        //    for (int i = 0; i < outputBuffer.Length; i++)
        //    {
        //        builder.Append(outputBuffer[i].ToString("X2"));
        //    }

        //    return builder.ToString();
        //}

    }
}