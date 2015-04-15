using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PauseSystem.Helpers;
using System.Globalization;

namespace PauseSystem.Models.Entity
{
    public static class RepositoryExtentions
    {
        //public static IList<CustomerDelivery> GetDeliveries(this IRepository<LeveringsProdukt> repository, UnitOfWork unitOfWork,
        //    DateTime startDate, DateTime endDate, int? kundeId)
        //{
        //    var qLeveringsProdukt = repository.AsQuerable();
        //    qLeveringsProdukt = qLeveringsProdukt.Where(x => x.TurLevering.Ture.Dato >= startDate && x.TurLevering.Ture.Dato <= endDate);
        //    if (kundeId.HasValue)
        //        qLeveringsProdukt = qLeveringsProdukt.Where(x => x.TurLevering.KundeId == kundeId.Value);

        //    return qLeveringsProdukt.Take(20).Select(x => new CustomerDelivery
        //    {
        //        Antal = x.Antal,
        //        VareNr = x.ProduktNr,
        //        Beskrivelse = x.Produkt.Navn,
        //        Pris = x.SalgsPris,
        //        SampletPris = x.SalgsPris
        //    }).ToList();




        //}

        public static IList<CustomerDeliveryAdresses> GetDeliveries(this IRepository<LeveringsProdukt> repository, UnitOfWork unitOfWork, 
            DateTime Start, DateTime End, int? kundeId)
        {
            var finalProdukter = new List<LeveringsProdukt>();
            var deliveries = new List<CustomerDeliveryAdresses>();

            var qleveringer = unitOfWork.Repository<TurLevering>().AsQuerable()
                                .Where(l => (l.Ture.Dato >= Start.Date && l.Ture.Dato <= End.Date));
            //.Take(20); && l.KundeId == kundeId
            var leveringMonday = unitOfWork.Repository<TurLevering>().AsQuerable().Max(k => k.Ture.Dato).GetNextMonday().Date;
            var leveringDateMax = leveringMonday.Date > Start.Date ? leveringMonday.Date : Start.Date;
            
            if (qleveringer.Any())
            {
                //if (qleveringer.Any(l => l.Ture.Dato.Date > leveringDateMax))
                //    leveringDateMax = qleveringer.Max(l => l.Ture.Dato.Date);
                finalProdukter.AddRange(qleveringer.SelectMany(l => l.LeveringProdukts));
            }
            //if (qleveringer.Any(l => l.Ture.Dato.Date > leveringDateMax.Date))
            //    leveringDateMax = qleveringer.Max(l => l.Ture.Dato.Date);

            //var week = TimeTool.GetWeekNumber(DateTime.Now);
            //int abbWeek = TimeTool.GetWeekNumber(leveringDateMax);

            var maxDate = TimeTool.GetDate(DateTime.Now.Year, TimeTool.GetWeekNumber(leveringDateMax), (int)DayOfWeek.Monday);
            maxDate = maxDate.Date > Start.Date ? maxDate.Date : Start.Date;
            if (leveringDateMax.Date > maxDate.Date)
                maxDate = leveringDateMax.Date;

            if (maxDate.Date < End.Date)
            {
                var abonnementer = unitOfWork.Repository<Abonnementer>().AsQuerable().Where(t => t.Kunde.Id == kundeId);
                //var ways = TimeTool.GetWeekAndYears(maxDate, End);

                foreach (var tmpway in TimeTool.GetWeekAndYears(maxDate, End))
                {
                    var ableveringer = abonnementer.GetLeveringerForService(tmpway.Year, tmpway.Week, 
                                    unitOfWork.Repository<ProductCustomerSpecialPrice>().AsQuerable());
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

            var produkter = finalProdukter.OrderBy(p => p.TurLevering.Ture.Dato).
                ThenBy(p => p.Produkt.Navn).ToList();
            foreach (var levering in produkter.Where(p => p.TurLevering.Ture.Dato.Date >= Start.Date && p.TurLevering.Ture.Dato <= End.Date))
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
                                .Deliveries.Add(new CustomerDelivery()
                                {
                                    Number = levering.Antal,
                                    Pris = levering.SalgsPris,
                                    Produkt = levering.Produkt.Navn,
                                    ProduktNumber = levering.ProduktNr,
                                    Id = levering.Id

                                });
                        }
                        else
                        {
                            deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                                .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                                .DeliverDates.Add(new CustomerDeliverDates()
                                {
                                    DayOfWeek = System.Globalization.CultureInfo.GetCultureInfo("da-DK")
                                    .DateTimeFormat.GetDayName(levering.TurLevering.Ture.Dato.DayOfWeek).ToUpper(),
                                    Date = levering.TurLevering.Ture.Dato,
                                    DateString =
                                        levering.TurLevering.Ture.Dato.ToShortDateString(),
                                    Deliveries = new List<CustomerDelivery>()
                                });
                            deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                                .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                                .DeliverDates.First(l => l.Date.Date == levering.TurLevering.Ture.Dato.Date)
                                .Deliveries.Add(new CustomerDelivery()
                                {
                                    Number = levering.Antal,
                                    Pris = levering.SalgsPris,
                                    Produkt = levering.Produkt.Navn,
                                    ProduktNumber = levering.ProduktNr,
                                    Id = levering.Id
                                });
                        }
                    }
                    else
                    {
                        deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                            .DeliveryWeeks.Add(new CustomerDeliveryWeek()
                            {
                                Week = levering.TurLevering.Ture.Week,
                                DeliverDates = new List<CustomerDeliverDates>()
                            });
                        deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                            .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                            .DeliverDates.Add(new CustomerDeliverDates()
                            {
                                DayOfWeek =
                                    System.Globalization.CultureInfo.GetCultureInfo("da-DK")
                                        .DateTimeFormat.GetDayName(levering.TurLevering.Ture.Dato.DayOfWeek).ToUpper(),

                                Date = levering.TurLevering.Ture.Dato,
                                DateString =
                                    levering.TurLevering.Ture.Dato.ToShortDateString(),
                                Deliveries = new List<CustomerDelivery>()
                            });
                        deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                            .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                            .DeliverDates.First(l => l.Date.Date == levering.TurLevering.Ture.Dato.Date)
                            .Deliveries.Add(new CustomerDelivery()
                            {
                                Number = levering.Antal,
                                Pris = levering.SalgsPris,
                                Produkt = levering.Produkt.Navn,
                                ProduktNumber = levering.ProduktNr,
                                Id = levering.Id
                            });
                    }
                }
                else
                {
                    deliveries.Add(new CustomerDeliveryAdresses()
                    {
                        Adress = levering.TurLevering.Adresser.Adresse + " " + levering.TurLevering.Adresser.Etage,
                        AdressId = levering.TurLevering.AdresseId,
                        City = levering.TurLevering.Adresser.City,
                        PostalCode = levering.TurLevering.Adresser.PostNr,
                        DeliveryWeeks = new List<CustomerDeliveryWeek>()
                    });
                    deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                        .DeliveryWeeks.Add(new CustomerDeliveryWeek()
                        {
                            Week = levering.TurLevering.Ture.Week,
                            DeliverDates = new List<CustomerDeliverDates>()
                        });
                    deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                        .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                        .DeliverDates.Add(new CustomerDeliverDates()
                        {
                            DayOfWeek =
                                System.Globalization.CultureInfo.GetCultureInfo("da-DK")
                                    .DateTimeFormat.GetDayName(levering.TurLevering.Ture.Dato.DayOfWeek)
                                    .ToUpper(),
                            Date = levering.TurLevering.Ture.Dato,
                            DateString =
                                levering.TurLevering.Ture.Dato.ToShortDateString(),
                            Deliveries = new List<CustomerDelivery>()
                        });
                    deliveries.First(m => m.AdressId == levering.TurLevering.AdresseId)
                        .DeliveryWeeks.First(dw => dw.Week == levering.TurLevering.Ture.Week)
                        .DeliverDates.First(l => l.Date.Date == levering.TurLevering.Ture.Dato.Date)
                        .Deliveries.Add(new CustomerDelivery()
                        {
                            Number = levering.Antal,
                            Pris = levering.SalgsPris,
                            Produkt = levering.Produkt.Navn,
                            ProduktNumber = levering.ProduktNr,
                            Id = levering.Id

                        });
                }
            }
            return deliveries;

        }

        public static IEnumerable<TurLevering> GetLeveringerForService(this IEnumerable<Abonnementer> abonnementer, int year, int week
            , IQueryable<ProductCustomerSpecialPrice> priser)
        {
            var kundeLeveringer = new List<TurLevering>();

            //priser.Load();
            foreach (var abonnement in abonnementer)
            {
                DateTime leveringsDato = TimeTool.GetDate(year, week, (int)abonnement.AbonnementRute.Ugedag);

                if (abonnement.AbonnementProdukts.Any(ap => ap.IsActive(leveringsDato) && !ap.OnPause(leveringsDato))
                    || abonnement.AbonnementProdukts.Any(ap => ap.IsInIntervalWeek(leveringsDato, week))
                    || abonnement.AbonnementProdukts.Any(ap => ap.IsIntervalOther(abonnement, leveringsDato, week, year)))
                {
                    var levering = new TurLevering()
                    {
                        Adresser = abonnement.LeveringsAdresser,
                        AdresseId = abonnement.LeveringsAdresseId,
                        Zindex = abonnement.RuteIndex,
                        Kunde = abonnement.Kunde,
                        KundeId = abonnement.KundeId,
                        LeveringsTid = leveringsDato.AddDays(-1),
                        Id = abonnement.Id,
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
                        }
                    }
                    if (levering.LeveringProdukts.Count > 0)
                        if (levering.Adresser != null && levering.Adresser.X.HasValue && levering.Adresser.Y.HasValue)
                            kundeLeveringer.Add(levering);




                }

            }
            return kundeLeveringer;
        }

        public static bool IsInIntervalWeek(this AbonnementProdukt abonnementProdukt, DateTime leveringsDato, int week)
        {
            int weeks = NumberOfWeeks(abonnementProdukt.StartDato, leveringsDato);
            if (abonnementProdukt.Interval == Interval.HverUge)
            {
                return true;

            }
            else if (abonnementProdukt.Interval == Interval.Lige)
            {
                if (week % 2 == 0)
                    return true;


            }
            else if (abonnementProdukt.Interval == Interval.Ulige)
            {
                if (week % 2 != 0)
                    return true;
            }
            else if (abonnementProdukt.Interval == Interval.Hver2uge)
            {
                if (weeks % 2 == 0)
                    return true;
            }
            else if (abonnementProdukt.Interval == Interval.Hver3uge)
            {
                if (weeks % 3 == 0)
                    return true;

            }
            else if (abonnementProdukt.Interval == Interval.Hver4uge)
            {
                if (weeks % 4 == 0)
                    return true;

            }
            else if (abonnementProdukt.Interval == Interval.Hver5uge)
            {


                if (weeks % 5 == 0)
                {

                    return true;
                }

            }
            else if (abonnementProdukt.Interval == Interval.Hver6uge)
            {
                if (weeks % 6 == 0)
                    return true;

            }
            else if (abonnementProdukt.Interval == Interval.Hver7uge)
            {
                if (weeks % 7 == 0)
                    return true;
            }
            else if (abonnementProdukt.Interval == Interval.Hver8uge)
            {
                if (weeks % 8 == 0)
                    return true;
            }
            else if (abonnementProdukt.Interval == Interval.Hver9uge)
            {
                if (weeks % 9 == 0)
                    return true;

            }
            else if (abonnementProdukt.Interval == Interval.Hver10uge)
            {
                if (weeks % 10 == 0)
                    return true;

            }
            else if (abonnementProdukt.Interval == Interval.Hver11uge)
            {
                if (weeks % 11 == 0)
                    return true;

            }
            else if (abonnementProdukt.Interval == Interval.Hver12uge)
            {
                if (weeks % 12 == 0)
                    return true;

            }
            else if (abonnementProdukt.Interval == Interval.Hver26uge)
            {
                if (weeks % 26 == 0)
                    return true;
            }
            if (abonnementProdukt.Interval == Interval.MåtteSkift)
            {
                if (leveringsDato.Date <= new DateTime(leveringsDato.Year, 11, 1).Date &&
                    leveringsDato.Date >= new DateTime(leveringsDato.Year, 3, 1).AddDays(-1).Date)
                {
                    if (weeks % 4 == 0)
                        return true;
                }
                else
                {
                    if (weeks % 2 == 0)
                        return true;
                }



            }
            return false;
        }
        public static bool IsIntervalOther(this AbonnementProdukt abonnementProdukt, Abonnementer abonnement, DateTime leveringsDato,
          int week, int year)
        {


            if (abonnementProdukt.Interval == Interval.FørstDagHverMåned)
            {

                DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Sunday);
                for (int i = 0; i < 7; i++)
                {
                    if (Date.Day == 1)
                        break;
                    else
                        Date = Date.AddDays(-1);
                }
                if (Date.Day == 1 && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
                {

                    return true;
                }

            }
            else if (abonnementProdukt.Interval == Interval.SidstDagHverMåned)
            {
                DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Monday);
                for (int i = 0; i <= 6; i++)
                {
                    if (Date.AddDays(1).Day == 1)
                        break;
                    else
                        Date = Date.AddDays(1);
                }
                if (Date.AddDays(1).Day == 1 && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
                {
                    return true;
                }
            }
            else if (abonnementProdukt.Interval == Interval.SidstArbejdsdagIMåned)
            {
                DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Monday);
                for (int i = 0; i <= 4; i++)
                {
                    if (Date.AddDays(1).Day == 1 || Date.DayOfWeek == DayOfWeek.Friday)
                        break;
                    else
                        Date = Date.AddDays(1);
                }
                if ((Date.AddDays(1).Day == 1 || Date.DayOfWeek == DayOfWeek.Friday) && abonnementProdukt.IsActive(Date) &&
                    !abonnementProdukt.OnPause(Date))
                {
                    return true;
                }
            }
            else if (abonnementProdukt.Interval == Interval.FørstArbejdsdagIMåned)
            {

                DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Friday);
                for (int i = 0; i <= 4; i++)
                {
                    if (Date.Day == 1)
                        break;
                    else
                        Date = Date.AddDays(-1);
                }
                if (Date.Day == 1 && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
                {
                    return true;
                }

            }
            else if (abonnementProdukt.Interval == Interval.SidsteValgteDagIMåned)
            {

                DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Monday);
                for (int i = 0; i <= 6; i++)
                {
                    if (Date.DayOfWeek == abonnement.Ugedag || Date.AddDays(1).Day == 1)
                        break;
                    else
                        Date = Date.AddDays(1);
                }
                if (Date.DayOfWeek == abonnement.Ugedag && Date.AddDays(7).Day <= 7
                    && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
                {
                    return true;
                }

            }
            else if (abonnementProdukt.Interval == Interval.FørsteValgteDagIMåned)
            {
                DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Sunday);
                for (int i = 0; i <= 6; i++)
                {
                    if (Date.DayOfWeek == abonnement.Ugedag || Date.Day == 1)
                        break;
                    else
                        Date = Date.AddDays(-1);
                }
                if (Date.Day <= 7 && Date.DayOfWeek == abonnement.Ugedag && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
                {
                    return true;
                }
            }
            else if (abonnementProdukt.Interval == Interval.LigeMåned)
            {
                var date = TimeTool.GetDate(year, week, abonnement.Ugedag);
                if (date.Month % 2 == 0
                    && date.Day <= 7 && abonnement.Ugedag == date.DayOfWeek
                    && abonnementProdukt.IsActive(date)
                    && !abonnementProdukt.OnPause(date))
                {
                    return true;
                }
            }
            else if (abonnementProdukt.Interval == Interval.UligeMåned)
            {
                var date = TimeTool.GetDate(year, week, abonnement.Ugedag);
                if (date.Month % 2 == 1
                    && date.Day <= 7
                    && abonnement.Ugedag == date.DayOfWeek
                    && abonnementProdukt.IsActive(date)
                    && !abonnementProdukt.OnPause(date))
                {
                    return true;
                }
            }
            return false;
        }
        public static int NumberOfWeeks(DateTime Fra, DateTime Til)
        {
            int WeekCount = 0;

            if (Fra > Til)
                return -1;
            var fra = new DateTime(Fra.Year, Fra.Month, Fra.Day);
            while (fra < Til)
            {
                fra = fra.AddDays(7);
                WeekCount++;
            }
            return WeekCount;
        }
        public static DateTime GetDate(int iYear, int iWeekNo, int iDayNo)
        {
            if (iWeekNo > 53)
                throw new Exception("Week is > 53");
            var jan1 = new DateTime(iYear, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            var firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = GetWeekNumber(jan1);

            var weekNum = iWeekNo;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            result = result.AddDays(-3);
            while (iWeekNo != GetWeekNumber(result) || iDayNo != (int)result.DayOfWeek || iYear != result.Year)
            {
                //året skal passe
                if (iYear != result.Year)
                    if (iYear > result.Year)
                        result = result.AddYears(1);
                    else if (iYear < result.Year)
                        result = result.AddYears(-1);
                // ugen skal passe
                if (iWeekNo != GetWeekNumber(result))
                    if (iWeekNo < GetWeekNumber(result))
                        result = result.AddDays(-7);
                    else if (iWeekNo > GetWeekNumber(result))
                        result = result.AddDays(7);

                //Dagen skal passe
                if (iDayNo > (int)result.DayOfWeek)
                {
                    while (iDayNo > (int)result.DayOfWeek)
                    {
                        result = result.AddDays(1);
                        if (iDayNo == (int)result.DayOfWeek)
                            break;
                    }
                }
                else if (iDayNo < (int)result.DayOfWeek)
                {
                    while (iDayNo < (int)result.DayOfWeek)
                    {
                        result = result.AddDays(-1);
                        if (iDayNo == (int)result.DayOfWeek)
                            break;
                    }
                }

            }
            return result;
        }
        public static int GetWeekNumber(DateTime dtPassed)
        {

            int weekNum = 0, year;
            TimeTool.GetWeekOfYear(dtPassed, YearWeekType.Iso8601, out year, out weekNum);
            return weekNum;
        }



        //public static IList<CustomerDelivery> GetDeliveriesForCustomer(this IRepository<LeveringsProdukt> repository, UnitOfWork unitOfWork, int kundeId, DateTime startDate, DateTime endDate)
        //{
        //    var finalProdukter = new List<LeveringsProdukt>();
        //    var qLeveringsProdukt = repository.AsQuerable();
        //    qLeveringsProdukt = qLeveringsProdukt.Where(x => x.TurLevering.Ture.Dato >= startDate && x.TurLevering.Ture.Dato <= endDate && x.TurLevering.KundeId == kundeId);

        //    return qLeveringsProdukt.Take(20).Select(x => new CustomerDelivery
        //    {
        //        Antal = x.Antal,
        //        VareNr = x.ProduktNr,
        //        Beskrivelse = x.Produkt.Navn,
        //        Pris = x.SalgsPris,
        //        SampletPris = x.SalgsPris
        //    }).ToList();



        //    //int kundeId = 0;
        //    //DateTime startDate = DateTime.Now, endDate = DateTime.Now;

        //    //var finalProdukter = new List<LeveringsProdukt>();
        //    //var qLeveringsProdukt = unitOfWork.Repository<LeveringsProdukt>().AsQuerable()
        //    //    .Where(x => x.TurLevering.Ture.Dato >= startDate && x.TurLevering.Ture.Dato <= endDate && x.TurLevering.KundeId == kundeId);

        //    //var leveringer = qLeveringsProdukt.ToList();
        //    //var week = TimeTool.GetWeekNumber(DateTime.Now);
        //    //var leveringsDate = TimeTool.GetNextMonday(unitOfWork.Repository<TurLevering>().AsQuerable().Max(k => k.Ture.Dato).Value);
        //    //var leveringsDateMax = leveringsDate.Date > startDate.Date ? leveringsDate.Date : startDate.Date;
        //    //if (leveringer.Count > 0)
        //    //{
        //    //    if (leveringer.Any(l => l.TurLevering.Ture.Dato.Value.Date > leveringsDateMax.Date))
        //    //        leveringsDateMax = leveringer.Max(l => l.TurLevering.Ture.Dato.Value.Date);
        //    //    finalProdukter.AddRange(leveringer);
        //    //}

        //    //if (leveringer.Any(l => l.TurLevering.Ture.Dato.Value.Date > leveringsDateMax.Date))
        //    //    leveringsDateMax = leveringer.Max(l => l.TurLevering.Ture.Dato.Value.Date);
        //    //int abbWeek = TimeTool.GetWeekNumber(leveringsDateMax);
        //    //var maxDate = TimeTool.GetDate(DateTime.Now.Year, abbWeek, (int)DayOfWeek.Monday);
        //    //maxDate = maxDate.Date > startDate.Date ? maxDate.Date : startDate.Date;
        //    //if (leveringsDateMax.Date > maxDate.Date)
        //    //    maxDate = leveringsDateMax.Date;


        //}


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
        //                            TurLevering = levering,
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
        //                            TurLevering = levering,
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