using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetNextMonday(this DateTime date)
        {
            //var returnDate = new DateTime(date.Year, date.Month, date.Day);
            while (date.DayOfWeek != DayOfWeek.Monday)
                date = date.AddDays(1);
            return date;

        }

        private static int GetWeekNumber(this DateTime date)
        {

            int weekNum = 0, year;
            TimeTool.GetWeekOfYear(date, YearWeekType.Iso8601, out year, out weekNum);
            return weekNum;
        }

        
    }
    public static class DateTimeExtensionMethods
    {

    }
}