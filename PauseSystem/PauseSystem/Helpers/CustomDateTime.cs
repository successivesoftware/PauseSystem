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
            return format == CustomDateTimeFormats.DefaultDate ? "MM'/'dd'/'yyyy"
                : format == CustomDateTimeFormats.DefaultDateTime ? "MM'/'dd'/'yyyy hh:mm tt"
                : format == CustomDateTimeFormats.DefaultDateTime12 ? "MM'/'dd'/'yyyy hh:mm tt"
                : format == CustomDateTimeFormats.DefaultDateTime24 ? "MM'/'dd'/'yyyy hh:mm"
                : format == CustomDateTimeFormats.Time12 ? "hh:mm tt"
                : format == CustomDateTimeFormats.Time24 ? "hh:mm"
                : "yyyy'/'MM'/'dd hh:mm:ss";
        }

        private static System.Globalization.CultureInfo GetCulture()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture;  //System.Configuration.ConfigurationManager.AppSettings[];
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

        /// <summary>
       /// returns true if given datetime is past from currentdatetime else false.
       /// </summary>
       /// <param name="datetime"></param>
       /// <returns></returns>
        public static bool IsPastDateTime(DateTime datetime)
        {
            return datetime < DateTime.Now;
        }

        /// <summary>
        /// returns true if given date is past from currentdate else false.
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static bool IsPastDate(DateTime datetime)
        {
            return datetime.Date < DateTime.Today;
        }

        #region Extensions

        /// <summary>
        /// convert datetime to date only string. if datetime is null then returns empty string.
        /// </summary>
        /// <returns>string format</returns>
        public static string ToDateString(this DateTime dateTime)
        {
            return ParseToStringFormat(dateTime, CustomDateTimeFormats.DefaultDate);
        }

       
        /// <summary>
        /// convert datetime to given string format. if datetime is null then returns empty string.
        /// </summary>
        /// <returns>string format</returns>
        public static string ToString(this DateTime? dateTime,CustomDateTimeFormats format)
        {
            return dateTime.HasValue ? ParseToStringFormat(dateTime.Value, format) : String.Empty;
        }

        /// <summary>
        /// returns Date of upcoming monday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetNextMonday(this DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
                date = date.AddDays(1);
            return date;
        }


        #endregion

    }

    public enum CustomDateTimeFormats
    {
        DefaultDate, DefaultDateTime, DefaultDateTime12, DefaultDateTime24, Time12, Time24
    }

}