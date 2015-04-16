using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PauseSystem.Helpers
{
    public enum YearWeekType
    {
        Calendar,
        Iso8601,
    } // enum YearWeekType

    // ------------------------------------------------------------------------
    public static class TimeTool
    {
        public static DateTime GetLastWorkingDayOfMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            var returnValue = new DateTime(year, month, days);
            while (returnValue.DayOfWeek == DayOfWeek.Saturday || returnValue.DayOfWeek == DayOfWeek.Sunday)
                returnValue = returnValue.AddDays(-1);
            return returnValue;
        }
        // ----------------------------------------------------------------------
        public static void GetWeekOfYear(DateTime moment, YearWeekType yearWeekType,
          out int year, out int weekOfYear)
        {
            GetWeekOfYear(moment, System.Threading.Thread.CurrentThread.CurrentCulture, yearWeekType, out year, out weekOfYear);
        } // GetWeekOfYear

        // ----------------------------------------------------------------------
        public static void GetWeekOfYear(DateTime moment, CultureInfo culture, YearWeekType yearWeekType,
          out int year, out int weekOfYear)
        {
            GetWeekOfYear(moment, culture, culture.DateTimeFormat.CalendarWeekRule, culture.DateTimeFormat.FirstDayOfWeek, yearWeekType,
              out year, out weekOfYear);
        } // GetWeekOfYear

        // ----------------------------------------------------------------------
        public static void GetWeekOfYear(DateTime moment, CultureInfo culture,
          CalendarWeekRule weekRule, DayOfWeek firstDayOfWeek, YearWeekType yearWeekType, out int year, out int weekOfYear)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            if (yearWeekType == YearWeekType.Iso8601 && weekRule == CalendarWeekRule.FirstFourDayWeek && firstDayOfWeek == DayOfWeek.Monday)
            {
                DayOfWeek day = culture.Calendar.GetDayOfWeek(moment);
                if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                {
                    moment = moment.AddDays(3);
                }
            }

            weekOfYear = culture.Calendar.GetWeekOfYear(moment, weekRule, firstDayOfWeek);
            year = moment.Year;
            if (weekOfYear >= 52 && moment.Month < 12)
            {
                year--;
            }
        } // GetWeekOfYear
        public static DateTime GetDate(int year, int week, DayOfWeek day)
        {
            var jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            CultureInfo ci = CultureInfo.CreateSpecificCulture("da-DK");
            var cal = ci.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = week;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            result = result.AddDays(-3);

            while (result.DayOfWeek != day)
            {
                result = result.AddDays(1);
            }

            return result;
        }

        /**
         * Internal getter
         * Finds the month and day.
         * 
         * @para year int [0 : 9999] (interval defined in DateTime)
         * @para dayNumber int [1 : 366]
         * @return int [1 - 12]  
         **/
        private static DateTime GetDate(int year, int dayNumber)
        {
            for (int month = 1; month < 12; month++)
            {
                int temp = 0;
                temp = DateTime.DaysInMonth(year, month);
                if (dayNumber <= 0)
                {
                    var tmpDt = new DateTime(year, month, 1);
                    return tmpDt.AddDays(dayNumber - 1);
                }
                if (dayNumber <= temp)
                {
                    return new DateTime(year, month, dayNumber);
                }
                else dayNumber -= temp;
            }
            //Unnecessary - I don't know how to specify format/range.
            return new DateTime(year, 12, dayNumber);
        }

        /**
         * Internal getter
         * Calculates the day of the year.
         * 
         * @para firstDayOfYear int [0 : 6]
         * @para day int [0 : 6]
         * return int [1 : 366]
         **/
        private static int GetDayOfYear(int year, int week, int day)
        {
            DayOfWeek firstDayOfYear = new DateTime(year, 1, 1).DayOfWeek;
            return (week - 1) * 7 + (day == 0 ? 7 : day) - ((int)firstDayOfYear == 0 ? 7 : ((int)firstDayOfYear)) + 1;
        }
        /**
         * Internal checker
         * If the input is incorrect it returns false.
         * Throws exceptions if the parameters are out of bounds.
         * 
         * @para year int [0 : 9999]
         * @para week int 
         * @para day int
         * return bool
         */
        private static bool InBounds(int year, int week, int day)
        {

            DayOfWeek firstDayOfYear = new DateTime(year, 1, 1).DayOfWeek;

            int daysInYear = (DateTime.IsLeapYear(year)) ? 366 : 365;

            if (week == 1 && day < (int)firstDayOfYear)
            {
                return false;
            }

            int todayDayOfYear = DateTime.Today.DayOfYear;

            int todaysWeek = todayDayOfYear / 7;
            if (todayDayOfYear % 7 != 0)
                todaysWeek++;

            //This (1) is only needed if one should not change the past.//
            //I don't know how to do bitwise operations.//
            //I think that would be more elegant and faster.//
            int today = int.Parse("" + DateTime.Today.Year + todaysWeek + DateTime.Today.Day);
            String weekString = "" + week;
            if (week < 10)
                weekString = "" + 0 + week;
            int date = int.Parse("" + year + weekString + day);

            //if (date < today)
            //    throw new Exception("date has past");
            //End (1)//

            if (week < 1 || week > 53)
                throw new ArgumentOutOfRangeException(paramName: "week");
            if (day < 0 || day > 6)
                throw new ArgumentOutOfRangeException(paramName: "day");
            if (GetDayOfYear(year, week, day) > (DateTime.IsLeapYear(year) ? 366 : 365))
            {
                //Console.Out.WriteLine("Date does not exist");
                //Console.Out.WriteLine("rendering on input needed...");
                return false;
            }
            return true;
        }

        /**
         * Getter
         * Corrects the input when necessary.
         * 
         * return DateTime
         **/
        public static DateTime GetDate(int year, int week, int day)
        {
            var jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            CultureInfo ci = CultureInfo.CreateSpecificCulture("da-DK");
            var cal = ci.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = week;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            result = result.AddDays(-3);
            var dayOfWeek = (DayOfWeek)day;
            while (dayOfWeek != result.DayOfWeek)
            {
                result = result.AddDays(1);
            }

            return result;
        }




        public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            var jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        //Storage Type : obsolete?//
        public class WeekAndYear
        {
            public int Year { get; set; }
            public int Week { get; set; }

            public WeekAndYear(int year, int week)
            {
                Year = year;
                Week = week;
            }

            public override string ToString()
            {
                return "Uge " + Week + " år " + Year;
            }
        }

        //Checker : Storage class : //
        public class WeekAndYears : List<WeekAndYear>
        {
            public bool Contains(int year, int week)
            {
                return this.Any(weekAndYear => weekAndYear.Year == year && weekAndYear.Week == week);
            }
        }

        //Getter : //
        public static WeekAndYears GetWeekAndYears(DateTime fra, DateTime til)
        {
            var returnValue = new WeekAndYears();
            if (fra.Date > til.Date)
                return null;
            int startWeek, startYear, endWeek, endYear;
            TimeTool.GetWeekOfYear(fra, YearWeekType.Iso8601, out startYear, out startWeek);
          //  ReturnValue.Add(new WeekAndYear(startYear, startWeek));
            while (fra.Date < til.Date)
            {

                TimeTool.GetWeekOfYear(fra, YearWeekType.Iso8601, out startYear, out startWeek);
                if (!returnValue.Contains(startYear, startWeek))
                    returnValue.Add(new WeekAndYear(startYear, startWeek));
                fra = fra.Date.AddDays(7);
            }
            TimeTool.GetWeekOfYear(til, YearWeekType.Iso8601, out endYear, out endWeek);
            if (!returnValue.Contains(endYear, endWeek))
                returnValue.Add(new WeekAndYear(endYear, endWeek));


            return returnValue;

        }

        //Getter : //
        public static int GetWeekNumber(DateTime dtPassed)
        {

            int weekNum = 0, year;
            TimeTool.GetWeekOfYear(dtPassed, YearWeekType.Iso8601, out year, out weekNum);
            return weekNum;
        }

        public static DateTime GetFirstWeekDay(DateTime date, DayOfWeek weekDay)
        {
            var returnDate = date;
            while (returnDate.DayOfWeek != weekDay)
            {
                returnDate = returnDate.AddDays(1);
            }
            return returnDate;
        }

    

    } // class TimeTool
}