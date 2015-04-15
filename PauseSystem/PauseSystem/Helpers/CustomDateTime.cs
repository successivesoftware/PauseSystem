using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem
{
    public static class CustomDateTime
    {

        #region Private Methods

        private static string GetFormat(CustomDateTimeFormats format)
        {
            return format == CustomDateTimeFormats.DefaultDate ? "MM/dd/yyyy"
                : format == CustomDateTimeFormats.DefaultDateTime ? "MM/dd/yyyy hh:mm tt"
                : format == CustomDateTimeFormats.DefaultDateTime12 ? "MM/dd/yyyy hh:mm tt"
                : format == CustomDateTimeFormats.DefaultDateTime24 ? "MM/dd/yyyy hh:mm"
                : format == CustomDateTimeFormats.Time12 ? "hh:mm tt"
                : format == CustomDateTimeFormats.Time24 ? "hh:mm"
                : "yyyy-dd-MM hh:mm:ss";
        }

        private static string ParseToStringFormat(DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        private static string ParseToStringFormat(DateTime dateTime, CustomDateTimeFormats format)
        {
            return ParseToStringFormat(dateTime, GetFormat(format));
        }


        #endregion

        public static DateTime GetNextMonday(this DateTime date)
        {
            //var returnDate = new DateTime(date.Year, date.Month, date.Day);
            while (date.DayOfWeek != DayOfWeek.Monday)
                date = date.AddDays(1);
            return date;

        }

        //private static int GetWeekNumber(this DateTime date)
        //{

        //    int weekNum = 0, year;
        //   // TimeTool.GetWeekOfYear(date, YearWeekType.Iso8601, out year, out weekNum);
        //    return weekNum;
        //}

        #region Extensions

        /// <summary>
        /// convert datetime to date only string. if datetime is null then returns empty string.
        /// </summary>
        /// <returns>string format</returns>
        public static string ToDateString(this DateTime? dateTime)
        {
            return dateTime.HasValue ? ParseToStringFormat(dateTime.Value, CustomDateTimeFormats.DefaultDate) : String.Empty;
        }

        /// <summary>
        /// convert datetime to given string format. if datetime is null then returns empty string.
        /// </summary>
        /// <returns>string format</returns>
        public static string ToString(this DateTime? dateTime,CustomDateTimeFormats format)
        {
            return dateTime.HasValue ? ParseToStringFormat(dateTime.Value, format) : String.Empty;
        }

        #endregion

    }

    public enum CustomDateTimeFormats
    {
        DefaultDate, DefaultDateTime, DefaultDateTime12, DefaultDateTime24, Time12, Time24

        //public const string DefaultDate = "MM/dd/yyyy";
        //public const string DefaultDateTime = "MM/dd/yyyy hh:mm tt";
    }

}