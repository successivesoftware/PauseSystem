using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem
{
    public static class CustomDateTime
    {
        #region Private Methods

        public static string GetFormat(CustomDateTimeFormats format)
        {
            return format == CustomDateTimeFormats.DefaultDate ? PauseSystem.Helpers.AppSettings.DefaultDateFormat // "MM'/'dd'/'yyyy"
                : format == CustomDateTimeFormats.DefaultDateTime ? PauseSystem.Helpers.AppSettings.DefaultDateFormat + " hh:mm tt"
                : format == CustomDateTimeFormats.DefaultDateTime12 ? PauseSystem.Helpers.AppSettings.DefaultDateFormat + " hh:mm tt"
                : format == CustomDateTimeFormats.DefaultDateTime24 ? PauseSystem.Helpers.AppSettings.DefaultDateFormat + " hh:mm"
                : format == CustomDateTimeFormats.Time12 ? "hh:mm tt"
                : format == CustomDateTimeFormats.Time24 ? "hh:mm"
                : "yyyy'/'MM'/'dd hh:mm:ss";
        }

        private static System.Globalization.CultureInfo GetCulture()
        {
            return new System.Globalization.CultureInfo(PauseSystem.Helpers.AppSettings.CultureName);  //System.Threading.Thread.CurrentThread.CurrentCulture;  //System.Configuration.ConfigurationManager.AppSettings[];
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
        /// <summary>
        /// Default Date Only Format  e.g. 20/05/2015
        /// </summary>
        DefaultDate, 
        /// <summary>
        /// Default Date and Time Format  e.g. 20/05/2015 01:00 PM
        /// </summary>
        DefaultDateTime, 
        /// <summary>
        ///  Default Date and Time Format (Time in 12 Hour format) e.g. 20/05/2015 01:00 PM
        /// </summary>
        DefaultDateTime12, 
        /// <summary>
        /// Default Date and Time Format (Time in 24 Hour format) e.g. 20/05/2015 13:00
        /// </summary>
        DefaultDateTime24, 
        /// <summary>
        /// Time in 12 Hour format e.g. 01:00 PM
        /// </summary>
        Time12, 
        /// <summary>
        /// Time in 24 Hour format e.g. 13:00
        /// </summary>
        Time24
    }

}