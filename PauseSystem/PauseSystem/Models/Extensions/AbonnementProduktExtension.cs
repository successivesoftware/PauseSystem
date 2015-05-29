using PauseSystem.Helpers;
using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PauseSystem.Models.Extensions
{
    public static class AbonnementProduktExtension
    {

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
    }
}