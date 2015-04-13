using PauseSystem.Helpers;
using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models.Entity
{
    //public static class AbonnementExtensions
    //{
    //    internal static Tuple<double, string> GetSpecialPrice(this List<ProductCustomerSpecialPrice> prices,
    //        int kundeId, int produktNr, int antal, DateTime date)
    //    {


    //        const int msKundeId = 679;
    //        var tp = new Tuple<double, string>(double.MaxValue, string.Empty);
    //        if (prices.Any(
    //            pc => pc.CustomerId == kundeId && pc.ProductNr == produktNr && pc.FromDate <= date && pc.ToDate >= date))
    //        {

    //            foreach (var pcsp in prices.Where(
    //                pc =>
    //                    pc.CustomerId == kundeId && pc.ProductNr == produktNr && pc.FromDate <= date &&
    //                    pc.ToDate >= date)
    //                .OrderByDescending(p => p.Antal))
    //            {
    //                if (antal >= pcsp.Antal)
    //                {
    //                    tp = new Tuple<double, string>(pcsp.Pris, "Kunde specialpris antal " + pcsp.Antal);
    //                    break;
    //                }
    //            }
    //        }
    //        if (prices.Any(
    //              pc => pc.CustomerId == msKundeId && pc.ProductNr == produktNr && pc.FromDate <= date && pc.ToDate >= date))
    //        {
    //            foreach (var pcsp in prices.Where(
    //                    pc => pc.CustomerId == msKundeId && pc.ProductNr == produktNr && pc.FromDate <= date && pc.ToDate >= date)
    //                    .OrderByDescending(p => p.Antal))
    //            {

    //                if (antal >= pcsp.Antal)
    //                {
    //                    if (tp.Item1.CompareTo(double.MaxValue) == 0)
    //                    {
    //                        if (tp.Item1 > pcsp.Pris)
    //                            tp = new Tuple<double, string>(pcsp.Pris, "Generel specialpris antal " + pcsp.Antal);
    //                    }
    //                    break;
    //                }
    //            }
    //        }

    //        if (tp.Item1.CompareTo(double.MaxValue) != 0)
    //            return tp;
    //        return null;

    //    }

    //    public static double GetKm(this Ture tur)
    //    {
    //        double ReturnValue = 0;
    //        var StartPoint = new PointLatLng(tur.StartAdresse.X.Value, tur.StartAdresse.Y.Value);
    //        PointLatLng EndPoint;
    //        MapRoute route;

    //        foreach (var levering in tur.Leveringer)
    //        {
    //            EndPoint = new PointLatLng(levering.Adresse.X.Value, levering.Adresse.Y.Value);
    //            route = GMapProviders.GoogleMap.GetRoute(StartPoint, EndPoint, false, false, 9);
    //            if (route != null)
    //                ReturnValue += route.Distance;
    //            StartPoint = EndPoint;
    //        }
    //        EndPoint = new PointLatLng(tur.EndAdresse.X.Value, tur.EndAdresse.Y.Value);
    //        route = GMapProviders.GoogleMap.GetRoute(StartPoint, EndPoint, false, false, 9);
    //        if (route != null)
    //            ReturnValue += route.Distance;
    //        return ReturnValue;
    //    }

    //    //public static Brush GetAbonnementRuteBrush(this IList<AbonnementRute> abonnementRuter, AbonnementRute rute)
    //    //{
    //    //    int index = -1;

    //    //    index = abonnementRuter.IndexOf(rute);
    //    //    IList<Brush> currentColors = new List<Brush>();
    //    //    currentColors.Add(Brushes.Black);
    //    //    currentColors.Add(Brushes.Blue);
    //    //    currentColors.Add(Brushes.Fuchsia);
    //    //    currentColors.Add(Brushes.Gray);
    //    //    currentColors.Add(Brushes.Green);
    //    //    currentColors.Add(Brushes.Lime);
    //    //    currentColors.Add(Brushes.Maroon);
    //    //    currentColors.Add(Brushes.Navy);
    //    //    currentColors.Add(Brushes.Olive);
    //    //    currentColors.Add(Brushes.Purple);
    //    //    currentColors.Add(Brushes.Red);
    //    //    currentColors.Add(Brushes.Silver);
    //    //    currentColors.Add(Brushes.Teal);
    //    //    currentColors.Add(Brushes.Yellow);
    //    //    currentColors.Add(Brushes.DarkSlateGray);
    //    //    currentColors.Add(Brushes.DarkOrchid);
    //    //    currentColors.Add(Brushes.Aqua);
    //    //    currentColors.Add(Brushes.Chartreuse);
    //    //    currentColors.Add(Brushes.GhostWhite);
    //    //    currentColors.Add(Brushes.Gainsboro);
    //    //    currentColors.Add(Brushes.PapayaWhip);
    //    //    currentColors.Add(Brushes.HotPink);
    //    //    currentColors.Add(Brushes.BlanchedAlmond);
    //    //    return currentColors.Count - 1 > index ? currentColors.ElementAt(index) : Brushes.White;



    //    //}
    //    public static List<Abonnementer> GetActiveWithFuture(this IEnumerable<Abonnementer> abonnements, bool aktiv, int year, int week)
    //    {
    //        DateTime dt = DateTime.Now;
    //        var returnValue = new List<Abonnement>();
    //        foreach (Abonnement abonnement in abonnements)
    //        {
    //            dt = tools.TimeTool.GetDate(year, week, abonnement.UgeDag);
    //            bool aktive = false;
    //            foreach (AbonnementProdukt abonnementProdukt in abonnement.AbonnementProdukter)
    //            {
    //                if (dt.Date <= abonnementProdukt.SlutDato.Date)
    //                    aktive = true;
    //            }
    //            if (aktiv == aktive)
    //                returnValue.Add(abonnement);
    //        }
    //        return returnValue;

    //    }
    //    public static IEnumerable<TurLevering> GetLeveringer(this IEnumerable<Abonnementer> abonnementer,
    //        int year, int week, List<ProductCustomerSpecialPrice> priser)
    //    {
    //        var kundeLeveringer = new List<TurLevering>();
    //        var abb = abonnementer.ToList();

    //        foreach (var abonnement in abb)
    //        {
    //            var kunde = abonnement.Kunde;
    //            DateTime leveringsDato = TimeTool.GetDate(year, week, abonnement.AbonnementRute.Ugedag);
    //            if (abonnement.AbonnementProdukts.Any(ap => ap.IsActive(leveringsDato)
    //                && !ap.OnPause(leveringsDato))
    //                || abonnement.AbonnementProdukts.Any(ap => ap.IsInIntervalWeek(leveringsDato, week))
    //                || abonnement.AbonnementProdukts.Any(ap => ap.IsIntervalOther(abonnement, leveringsDato, week, year)))
    //            {
    //                var levering = new TurLevering()
    //                {
    //                    Abonnementer = abonnement,
    //                    AbonnementId = abonnement.Id,
    //                    Adresser = abonnement.LeveringsAdresser,
    //                    AdresseId = abonnement.LeveringsAdresseId.Value,
    //                    Zindex = abonnement.RuteIndex.Value,
    //                    Kunde = kunde,
    //                    KundeId = abonnement.KundeId,
    //                    LeveringsTid = leveringsDato.AddDays(-1),
    //                    Ture = new Ture() { Dato = leveringsDato, Week = week, Year = year, 
    //                        //UgeDag = abonnement.AbonnementRute.Ugedag,
    //                        TurId = abonnement.AbonnementRute.RuteId }

    //                };

    //                if (abonnement.PrintPakkeList)
    //                    levering.PrintPakkeListe = true;
    //                if (abonnement.PrintPakkeDato.HasValue && leveringsDato.Date == abonnement.PrintPakkeDato.Value.Date)
    //                    levering.PrintPakkeListe = true;


    //                foreach (var abonnementProdukt in abonnement.AbonnementProdukts)
    //                {
    //                    if (abonnementProdukt.IsActive(leveringsDato) && !abonnementProdukt.OnPause(leveringsDato))
    //                    {
    //                        if (abonnementProdukt.IsInIntervalWeek(leveringsDato, week))
    //                        {
    //                            //var lp = new LeveringsProdukt(abonnementProdukt,
    //                            //    priser, kunde, leveringsDato)
    //                            //{
    //                            //    TurLevering = levering,

    //                            //};

    //                            var lp = new LeveringsProdukt();

    //                            if (abonnementProdukt.AbonnementProduktChanges.Any(p => p.Date == leveringsDato))
    //                            {
    //                                foreach (var apc in abonnementProdukt.AbonnementProduktChanges.Where(
    //                                    p => p.Date == leveringsDato))
    //                                {
    //                                    if (!apc.ProduktNumber.HasValue)
    //                                    {
    //                                        lp.Antal += apc.Antal;
    //                                    }
    //                                    else if (lp.EfGrøntkasseLevering != null)
    //                                    {
    //                                        if (lp.EfGrøntkasseLevering.
    //                                            GrøntkasseLeveringsProdukter.Any(p => p.ProduktNr == apc.ProduktNumber))
    //                                        {
    //                                            var efgk = lp.EfGrøntkasseLevering.
    //                                                GrøntkasseLeveringsProdukter.First(
    //                                                    p => p.ProduktNr == apc.ProduktNumber);
    //                                            if ((efgk.Antal + apc.Antal) == 0)
    //                                            {
    //                                                lp.EfGrøntkasseLevering.GrøntkasseLeveringsProdukter.Remove(efgk);
    //                                            }
    //                                            else
    //                                            {
    //                                                efgk.Antal += apc.Antal;
    //                                            }
    //                                        }
    //                                        else
    //                                        {
    //                                            var efgk = new GrøntkasseLeveringsProdukt()
    //                                            {
    //                                                Antal = apc.Antal,
    //                                                Produkt = apc.Produkt,
    //                                                ProduktNr = apc.ProduktNumber.Value,
    //                                                GrøntkasseLevering = lp.EfGrøntkasseLevering,
    //                                                SpecialPris = priser.GetSalgsPris(kunde.Id, apc.ProduktNumber.Value, apc.Antal, leveringsDato) != 0 ?
    //                                                priser.GetSalgsPris(kunde.Id, apc.ProduktNumber.Value, apc.Antal, leveringsDato) : apc.Produkt.SalgsPris
    //                                            };
    //                                            lp.EfGrøntkasseLevering.GrøntkasseLeveringsProdukter.Add(efgk);
    //                                        }
    //                                    }
    //                                }
    //                            }

    //                            if (lp.Antal > 0)
    //                                if (levering.Produkter.All(p => p.Produkt.ProduktNr != lp.Produkt.ProduktNr))
    //                                    levering.Produkter.Add(lp);
    //                                else
    //                                    levering.Produkter.First(p => p.Produkt.ProduktNr == lp.Produkt.ProduktNr).Antal +=
    //                                        lp.Antal;


    //                        }
    //                        else if (abonnementProdukt.IsIntervalOther(abonnement, leveringsDato, week, year))
    //                        {
    //                            var lp = new LeveringsProdukt(abonnementProdukt, priser, abonnement.Kunde, leveringsDato)
    //                            {
    //                                KundeLevering = levering,

    //                            };
    //                            if (abonnementProdukt.AbonnementProduktChanges.Any(p => p.Dato == leveringsDato))
    //                            {
    //                                foreach (var apc in abonnementProdukt.AbonnementProduktChanges.Where(
    //                                    p => p.Dato == leveringsDato))
    //                                {
    //                                    if (!apc.ProduktNumber.HasValue)
    //                                    {
    //                                        lp.Antal += apc.Antal;
    //                                    }
    //                                    else if (lp.EfGrøntkasseLevering != null)
    //                                    {
    //                                        if (lp.EfGrøntkasseLevering.
    //                                            GrøntkasseLeveringsProdukter.Any(p => p.ProduktNr == apc.ProduktNumber))
    //                                        {
    //                                            var efgk = lp.EfGrøntkasseLevering.
    //                                                GrøntkasseLeveringsProdukter.First(
    //                                                    p => p.ProduktNr == apc.ProduktNumber);
    //                                            if ((efgk.Antal + apc.Antal) == 0)
    //                                            {
    //                                                lp.EfGrøntkasseLevering.GrøntkasseLeveringsProdukter.Remove(efgk);
    //                                            }
    //                                            else
    //                                            {
    //                                                efgk.Antal += apc.Antal;
    //                                            }
    //                                        }
    //                                        else
    //                                        {
    //                                            var efgk = new GrøntkasseLeveringsProdukt()
    //                                            {
    //                                                Antal = apc.Antal,
    //                                                Produkt = apc.Produkt,
    //                                                ProduktNr = apc.ProduktNumber.Value,
    //                                                GrøntkasseLevering = lp.EfGrøntkasseLevering,
    //                                                SpecialPris = priser.GetSalgsPris(kunde.Id, apc.ProduktNumber.Value, apc.Antal, leveringsDato) != 0 ?
    //                                                priser.GetSalgsPris(kunde.Id, apc.ProduktNumber.Value, apc.Antal, leveringsDato) : apc.Produkt.SalgsPris
    //                                            };
    //                                            lp.EfGrøntkasseLevering.GrøntkasseLeveringsProdukter.Add(efgk);
    //                                        }
    //                                    }
    //                                }
    //                            }
    //                            if (lp.Antal > 0)

    //                                if (levering.Produkter.All(p => p.Produkt.ProduktNr != lp.Produkt.ProduktNr))
    //                                    levering.Produkter.Add(lp);
    //                                else
    //                                    levering.Produkter.First(p => p.Produkt.ProduktNr == lp.Produkt.ProduktNr).Antal +=
    //                                        lp.Antal;

    //                        }
    //                    }
    //                }
    //                if (abonnement.AbonnementChanges.Any(p => p.Dato == leveringsDato))
    //                {
    //                    var acs = abonnement.AbonnementChanges.Where(p => p.Dato == leveringsDato).ToList();
    //                    foreach (var abonnementChange in acs)
    //                    {
    //                        if (levering.Produkter.Any(p => p.ProduktNr == abonnementChange.ProduktNumber))
    //                        {
    //                            levering.Produkter.First(p => p.ProduktNr == abonnementChange.ProduktNumber).Antal +=
    //                                abonnementChange.Antal;
    //                        }
    //                        else
    //                        {
    //                            var tmpLp = new LeveringsProdukt()
    //                            {
    //                                Antal = abonnementChange.Antal,
    //                                Produkt = abonnementChange.Product,
    //                                KundeLevering = levering,
    //                                SalgsPris = priser.GetSalgsPris(kunde.Id, abonnementChange.ProduktNumber, abonnementChange.Antal, leveringsDato) != 0 ?
    //                                priser.GetSalgsPris(kunde.Id, abonnementChange.ProduktNumber, abonnementChange.Antal, leveringsDato) : abonnementChange.Product.SalgsPris,
    //                                KostPris = abonnementChange.Product.KostPris,
    //                                GrossistPris = abonnementChange.Product.GrossistPris,
    //                                ProduktNr = abonnementChange.ProduktNumber,
    //                                Stk = abonnementChange.Product.Stk,
    //                                Provision = abonnementChange.Product.Provision

    //                            };
    //                            levering.Produkter.Add(tmpLp);
    //                        }
    //                    }
    //                }
    //                if (levering.Produkter.Any(p => p.Antal > 0))
    //                    if (levering.Adresse != null && levering.Adresse.X.HasValue && levering.Adresse.Y.HasValue)
    //                        kundeLeveringer.Add(levering);
    //            }

    //        }
    //        return kundeLeveringer;
    //    }

    //    public static double GetSalgsPris(this List<ProductCustomerSpecialPrice> priser, int kundeId, int produktNumber,
    //        int antal, DateTime dato)
    //    {
    //        var test = priser.GetSpecialPrice(kundeId, produktNumber, antal, dato);
    //        if (test != null)
    //        {
    //            return test.Item1;


    //        }
    //        return 0;
    //    }
    //    public static double GetKm(this AbonnementRute tur)
    //    {
    //        double returnValue = 0;
    //        if (tur.StartAdresse.X != null && tur.StartAdresse.Y != null)
    //        {
    //            var startPoint = new PointLatLng(tur.StartAdresse.X.Value, tur.StartAdresse.Y.Value);
    //            PointLatLng endPoint;
    //            MapRoute route;

    //            foreach (var levering in tur.Abonnementer)
    //            {
    //                endPoint = new PointLatLng(levering.LeveringsAdresse.X.Value, levering.LeveringsAdresse.Y.Value);
    //                route = GMapProviders.GoogleMap.GetRoute(startPoint, endPoint, false, false, 9);
    //                if (route != null)
    //                    returnValue += route.Distance;
    //                startPoint = endPoint;
    //            }
    //            endPoint = new PointLatLng(tur.EndAdresse.X.Value, tur.EndAdresse.Y.Value);
    //            route = GMapProviders.GoogleMap.GetRoute(startPoint, endPoint, false, false, 9);
    //            if (route != null)
    //                returnValue += route.Distance;
    //        }

    //        return returnValue;
    //    }
    //    public static void CalculateKm(this AbonnementRute tur)
    //    {
    //        double ReturnValue = 0;
    //        var StartPoint = new PointLatLng(tur.StartAdresse.X.Value, tur.StartAdresse.Y.Value);
    //        PointLatLng EndPoint;
    //        MapRoute route;
    //        foreach (var levering in tur.Abonnementer)
    //        {
    //            if (levering.LeveringsAdresse.X.HasValue &&
    //                levering.LeveringsAdresse.Y.HasValue)
    //            {
    //                EndPoint = new PointLatLng(levering.LeveringsAdresse.X.Value, levering.LeveringsAdresse.Y.Value);
    //                route = GMapProviders.GoogleMap.GetRoute(StartPoint, EndPoint, false, false, 9);
    //                if (route != null)
    //                    ReturnValue += route.Distance;

    //                StartPoint = EndPoint;
    //            }
    //        }
    //        EndPoint = new PointLatLng(tur.EndAdresse.X.Value, tur.EndAdresse.Y.Value);
    //        route = GMapProviders.GoogleMap.GetRoute(StartPoint, EndPoint, false, false, 9);
    //        if (route != null)
    //            ReturnValue += route.Distance;

    //        tur.Km = ReturnValue;
    //    }

    //    public static bool IsActive(this Abonnementer abonnement, DateTime date)
    //    {
    //        bool returnValue = false;
    //        foreach (AbonnementProdukt abonnementProdukt in abonnement.AbonnementProdukts)
    //        {
    //            if (abonnementProdukt.StartDato.Value.Date <= date.Date && abonnementProdukt.SlutDato.Value.Date >= date.Date)
    //            {
    //                returnValue = true;
    //            }

    //        }
    //        return returnValue;
    //    }
    //    public static bool OnPause(this Abonnementer abonnement, DateTime date)
    //    {
    //        bool returnValue = true;
    //        foreach (AbonnementProdukt abonnementProdukt in abonnement.AbonnementProdukts)
    //        {
    //            if (abonnementProdukt.StartDato.Value.Date <= date.Date && abonnementProdukt.SlutDato.Value.Date >= date.Date)
    //            {
    //                if (!abonnementProdukt.OnPause(date))
    //                    returnValue = false;
    //            }
    //        }
    //        return returnValue;
    //    }
    //    public static bool IsActive(this AbonnementProdukt abonnementProdukt, DateTime date)
    //    {
    //        if (abonnementProdukt.StartDato.Value.Date <= date.Date && abonnementProdukt.SlutDato.Value.Date >= date.Date)
    //            return true;
    //        return false;
    //    }
    //    public static bool OnPause(this AbonnementProdukt abonnementProdukt, DateTime date)
    //    {
    //        foreach (var abonnementProduktPause in abonnementProdukt.AbbonnementProduktPauses)
    //        {
    //            if (date.Date >= abonnementProduktPause.Start.Date && date.Date <= abonnementProduktPause.Slut.Date)
    //                return true;
    //        }
    //        return false;

    //    }
    //    public static bool HasFuturePause(this AbonnementProdukt abonnementProdukt, DateTime dateTime)
    //    {
    //        bool returnValue = false;

    //        foreach (var abonnementProduktPause in abonnementProdukt.AbbonnementProduktPauses)
    //        {
    //            if (abonnementProduktPause.Slut.Date >= dateTime.Date)
    //                returnValue = true;
    //        }
    //        return returnValue;
    //    }
    //    public static bool IsInIntervalWeek(this AbonnementProdukt abonnementProdukt, DateTime leveringsDato, int week)
    //    {
    //        int weeks = NumberOfWeeks(abonnementProdukt.StartDato.Value, leveringsDato);
    //        if (abonnementProdukt.Interval == (int)Interval.HverUge)
    //        {
    //            return true;

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Lige)
    //        {
    //            if (week % 2 == 0)
    //                return true;


    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Ulige)
    //        {
    //            if (week % 2 != 0)
    //                return true;
    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver2uge)
    //        {
    //            if (weeks % 2 == 0)
    //                return true;
    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver3uge)
    //        {
    //            if (weeks % 3 == 0)
    //                return true;

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver4uge)
    //        {
    //            if (weeks % 4 == 0)
    //                return true;

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver5uge)
    //        {


    //            if (weeks % 5 == 0)
    //            {

    //                return true;
    //            }

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver6uge)
    //        {
    //            if (weeks % 6 == 0)
    //                return true;

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver7uge)
    //        {
    //            if (weeks % 7 == 0)
    //                return true;
    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver8uge)
    //        {
    //            if (weeks % 8 == 0)
    //                return true;
    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver9uge)
    //        {
    //            if (weeks % 9 == 0)
    //                return true;

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver10uge)
    //        {
    //            if (weeks % 10 == 0)
    //                return true;

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver11uge)
    //        {
    //            if (weeks % 11 == 0)
    //                return true;

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver12uge)
    //        {
    //            if (weeks % 12 == 0)
    //                return true;

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.Hver26uge)
    //        {
    //            if (weeks % 26 == 0)
    //                return true;
    //        }
    //        if (abonnementProdukt.Interval == (int)Interval.MåtteSkift)
    //        {
    //            if (leveringsDato.Date <= new DateTime(leveringsDato.Year, 11, 1).Date &&
    //                leveringsDato.Date >= new DateTime(leveringsDato.Year, 3, 1).AddDays(-1).Date)
    //            {
    //                if (weeks % 4 == 0)
    //                    return true;
    //            }
    //            else
    //            {
    //                if (weeks % 2 == 0)
    //                    return true;
    //            }



    //        }
    //        return false;
    //    }
    //    public static bool IsIntervalOther(this AbonnementProdukt abonnementProdukt, Abonnementer abonnement, DateTime leveringsDato,
    //      int week, int year)
    //    {


    //        if (abonnementProdukt.Interval == (int)Interval.FørstDagHverMåned)
    //        {

    //            DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Sunday);
    //            for (int i = 0; i < 7; i++)
    //            {
    //                if (Date.Day == 1)
    //                    break;
    //                else
    //                    Date = Date.AddDays(-1);
    //            }
    //            if (Date.Day == 1 && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
    //            {

    //                return true;
    //            }

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.SidstDagHverMåned)
    //        {
    //            DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Monday);
    //            for (int i = 0; i <= 6; i++)
    //            {
    //                if (Date.AddDays(1).Day == 1)
    //                    break;
    //                else
    //                    Date = Date.AddDays(1);
    //            }
    //            if (Date.AddDays(1).Day == 1 && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
    //            {
    //                return true;
    //            }
    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.SidstArbejdsdagIMåned)
    //        {
    //            DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Monday);
    //            for (int i = 0; i <= 4; i++)
    //            {
    //                if (Date.AddDays(1).Day == 1 || Date.DayOfWeek == DayOfWeek.Friday)
    //                    break;
    //                else
    //                    Date = Date.AddDays(1);
    //            }
    //            if ((Date.AddDays(1).Day == 1 || Date.DayOfWeek == DayOfWeek.Friday) && abonnementProdukt.IsActive(Date) &&
    //                !abonnementProdukt.OnPause(Date))
    //            {
    //                return true;
    //            }
    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.FørstArbejdsdagIMåned)
    //        {

    //            DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Friday);
    //            for (int i = 0; i <= 4; i++)
    //            {
    //                if (Date.Day == 1)
    //                    break;
    //                else
    //                    Date = Date.AddDays(-1);
    //            }
    //            if (Date.Day == 1 && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
    //            {
    //                return true;
    //            }

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.SidsteValgteDagIMåned)
    //        {

    //            DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Monday);
    //            for (int i = 0; i <= 6; i++)
    //            {
    //                if ((int)Date.DayOfWeek == abonnement.Ugedag.Value || Date.AddDays(1).Day == 1)
    //                    break;
    //                else
    //                    Date = Date.AddDays(1);
    //            }
    //            if ((int)Date.DayOfWeek == abonnement.Ugedag && Date.AddDays(7).Day <= 7
    //                && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
    //            {
    //                return true;
    //            }

    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.FørsteValgteDagIMåned)
    //        {
    //            DateTime Date = TimeTool.GetDate(year, week, (int)DayOfWeek.Sunday);
    //            for (int i = 0; i <= 6; i++)
    //            {
    //                if ((int)Date.DayOfWeek == abonnement.Ugedag.Value || Date.Day == 1)
    //                    break;
    //                else
    //                    Date = Date.AddDays(-1);
    //            }
    //            if (Date.Day <= 7 && ((int)Date.DayOfWeek) == abonnement.Ugedag.Value && abonnementProdukt.IsActive(Date) && !abonnementProdukt.OnPause(Date))
    //            {
    //                return true;
    //            }
    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.LigeMåned)
    //        {
    //            var date = TimeTool.GetDate(year, week, abonnement.Ugedag.Value);
    //            if (date.Month % 2 == 0
    //                && date.Day <= 7 && abonnement.Ugedag.Value == (int)date.DayOfWeek
    //                && abonnementProdukt.IsActive(date)
    //                && !abonnementProdukt.OnPause(date))
    //            {
    //                return true;
    //            }
    //        }
    //        else if (abonnementProdukt.Interval == (int)Interval.UligeMåned)
    //        {
    //            var date = TimeTool.GetDate(year, week, abonnement.Ugedag.Value);
    //            if (date.Month % 2 == 1
    //                && date.Day <= 7
    //                && abonnement.Ugedag == (int)date.DayOfWeek
    //                && abonnementProdukt.IsActive(date)
    //                && !abonnementProdukt.OnPause(date))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //    public static int NumberOfWeeks(DateTime Fra, DateTime Til)
    //    {
    //        int WeekCount = 0;

    //        if (Fra > Til)
    //            return -1;
    //        var fra = new DateTime(Fra.Year, Fra.Month, Fra.Day);
    //        while (fra < Til)
    //        {
    //            fra = fra.AddDays(7);
    //            WeekCount++;
    //        }
    //        return WeekCount;
    //    }
    //    public static DateTime GetDate(int iYear, int iWeekNo, int iDayNo)
    //    {
    //        if (iWeekNo > 53)
    //            throw new Exception("Week is > 53");
    //        var jan1 = new DateTime(iYear, 1, 1);
    //        int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

    //        var firstThursday = jan1.AddDays(daysOffset);
    //        var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
    //        int firstWeek = GetWeekNumber(jan1);

    //        var weekNum = iWeekNo;
    //        if (firstWeek <= 1)
    //        {
    //            weekNum -= 1;
    //        }
    //        var result = firstThursday.AddDays(weekNum * 7);
    //        result = result.AddDays(-3);
    //        while (iWeekNo != GetWeekNumber(result) || iDayNo != (int)result.DayOfWeek || iYear != result.Year)
    //        {
    //            //året skal passe
    //            if (iYear != result.Year)
    //                if (iYear > result.Year)
    //                    result = result.AddYears(1);
    //                else if (iYear < result.Year)
    //                    result = result.AddYears(-1);
    //            // ugen skal passe
    //            if (iWeekNo != GetWeekNumber(result))
    //                if (iWeekNo < GetWeekNumber(result))
    //                    result = result.AddDays(-7);
    //                else if (iWeekNo > GetWeekNumber(result))
    //                    result = result.AddDays(7);

    //            //Dagen skal passe
    //            if (iDayNo > (int)result.DayOfWeek)
    //            {
    //                while (iDayNo > (int)result.DayOfWeek)
    //                {
    //                    result = result.AddDays(1);
    //                    if (iDayNo == (int)result.DayOfWeek)
    //                        break;
    //                }
    //            }
    //            else if (iDayNo < (int)result.DayOfWeek)
    //            {
    //                while (iDayNo < (int)result.DayOfWeek)
    //                {
    //                    result = result.AddDays(-1);
    //                    if (iDayNo == (int)result.DayOfWeek)
    //                        break;
    //                }
    //            }

    //        }
    //        return result;
    //    }
    //    public static int GetWeekNumber(DateTime dtPassed)
    //    {

    //        int weekNum = 0, year;
    //        TimeTool.GetWeekOfYear(dtPassed, YearWeekType.Iso8601, out year, out weekNum);
    //        return weekNum;
    //    }
    //}
}