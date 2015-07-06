using PauseSystem.Helpers;
using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models.Extensions
{

    public static class AbonnementerExtension
    {
        public static IEnumerable<TurLevering> GetLeveringerForService(this IEnumerable<Abonnementer> abonnementer, int year, int week
           , IQueryable<ProductCustomerSpecialPrice> priser)
        {
            var kundeLeveringer = new List<TurLevering>();

            //priser.Load();
            foreach (var abonnement in abonnementer)
            {
                if (abonnement.AbonnementRute == null)
                    continue;
                DateTime leveringsDato = TimeTool.GetDate(year, week, (int)abonnement.AbonnementRute.Ugedag);

                if (abonnement.AbonnementProdukts.Any(ap => ap.IsActive(leveringsDato) && !ap.OnPause(leveringsDato))
                    || abonnement.AbonnementProdukts.Any(ap => ap.IsInIntervalWeek(leveringsDato, week))
                    || abonnement.AbonnementProdukts.Any(ap => ap.IsIntervalOther(abonnement, leveringsDato, week, year)))
                {
                    var levering = new TurLevering()
                    {
                        Adresser = abonnement.LeveringsAdresse,
                        AdresseId = abonnement.LeveringsAdresseId,
                        Zindex = abonnement.RuteIndex,
                        //Kunde = abonnement.Kunde,
                        KundeId = abonnement.KundeId,
                        LeveringsTid = leveringsDato.AddDays(-1),
                        AbonnementId = abonnement.Id,
                        Ture = new Ture() { Week = week, Year = year, DayOfWeek = abonnement.AbonnementRute.Ugedag, TurId = abonnement.AbonnementRute.RuteId }
                    };

                    if (abonnement.PrintPakkeList)
                        levering.PrintPakkeListe = true;
                    if (abonnement.PrintPakkeDato.HasValue && leveringsDato.Date == abonnement.PrintPakkeDato.Value.Date)
                        levering.PrintPakkeListe = true;

                    foreach (var abonnementProdukt in abonnement.AbonnementProdukts)
                    {
                        if (abonnementProdukt.IsActive(leveringsDato) && !abonnementProdukt.OnPause(leveringsDato))
                        {
                            if (abonnementProdukt.IsInIntervalWeek(leveringsDato, week))
                            {
                                var lp = new LeveringsProdukt()
                                {
                                    TurLevering = levering,
                                    ProduktNr = abonnementProdukt.ProduktNr,
                                    Produkt = abonnementProdukt.Produkt,
                                    Antal = abonnementProdukt.Antal,
                                    Id = abonnementProdukt.Id,
                                    GrossistPris = abonnementProdukt.Produkt.GrossistPris,
                                    Weight = abonnementProdukt.Produkt.Weight,
                                    KostPris = abonnementProdukt.Produkt.KostPris,
                                    PrintLabel = abonnementProdukt.PrintLabel,
                                    Provision = abonnementProdukt.Produkt.Provision,
                                    SalgsPris = abonnementProdukt.Produkt.SalgsPris
                                };
                                if (priser.Any(pc => pc.CustomerId == levering.KundeId && pc.ProductNr == abonnementProdukt.ProduktNr
                                    && pc.FromDate <= leveringsDato && pc.ToDate >= leveringsDato))
                                {
                                    foreach (var pcsp in priser.Where(pc => pc.CustomerId == levering.KundeId && pc.ProductNr ==
                                        abonnementProdukt.ProduktNr && pc.FromDate <= leveringsDato && pc.ToDate >= leveringsDato)
                                        .OrderByDescending(p => p.Antal))
                                    {
                                        if (abonnementProdukt.Antal >= pcsp.Antal)
                                        {
                                            lp.SalgsPris = pcsp.Pris;
                                            break;
                                        }
                                    }
                                }
                                if (levering.LeveringProdukts.All(p => p.Produkt.ProduktNr != lp.Produkt.ProduktNr))
                                    levering.LeveringProdukts.Add(lp);
                                else
                                    levering.LeveringProdukts.First(p => p.Produkt.ProduktNr == lp.Produkt.ProduktNr).Antal +=
                                        lp.Antal;
                            }
                            else if (abonnementProdukt.IsIntervalOther(abonnement, leveringsDato, week, year))
                            {
                                var lp = new LeveringsProdukt()
                                {
                                    TurLevering = levering,
                                    ProduktNr = abonnementProdukt.ProduktNr,
                                    Produkt = abonnementProdukt.Produkt,
                                    Antal = abonnementProdukt.Antal,
                                    Id = abonnementProdukt.Id,
                                    GrossistPris = abonnementProdukt.Produkt.GrossistPris,
                                    Weight = abonnementProdukt.Produkt.Weight,
                                    KostPris = abonnementProdukt.Produkt.KostPris,
                                    PrintLabel = abonnementProdukt.PrintLabel
                                    ,
                                    Provision = abonnementProdukt.Produkt.Provision,
                                    SalgsPris = abonnementProdukt.Produkt.SalgsPris
                                };
                                //if (priser.Any(pc => pc.CustomerId == levering.KundeId && pc.ProductNr == abonnementProdukt.ProduktNr
                                //    && pc.FromDate <= leveringsDato && pc.ToDate >= leveringsDato))
                                //{
                                foreach (var pcsp in priser.Where(pc => pc.CustomerId == levering.KundeId && pc.ProductNr ==
                                    abonnementProdukt.ProduktNr && pc.FromDate <= leveringsDato && pc.ToDate >= leveringsDato)
                                    .OrderByDescending(p => p.Antal))
                                {
                                    if (abonnementProdukt.Antal >= pcsp.Antal)
                                    {
                                        lp.SalgsPris = pcsp.Pris;
                                        break;
                                    }
                                }
                                // }
                                if (levering.LeveringProdukts.All(p => p.Produkt.ProduktNr != lp.Produkt.ProduktNr))
                                    levering.LeveringProdukts.Add(lp);
                                else
                                    levering.LeveringProdukts.First(p => p.Produkt.ProduktNr == lp.Produkt.ProduktNr).Antal += lp.Antal;
                            }
                        }
                    }
                    if (levering.LeveringProdukts.Any())
                    {
                        if (levering.Adresser != null && levering.Adresser.X.HasValue && levering.Adresser.Y.HasValue)
                            kundeLeveringer.Add(levering);
                    }
                }

            }
            return kundeLeveringer.Distinct().ToList();
        }



    }


}