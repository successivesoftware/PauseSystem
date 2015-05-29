using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PauseSystem.Helpers
{
    public static class UIHelper
    {

        private static TextInfo _TextInfo;
        private static TextInfo TextInfo
        {
            get
            {
                return (_TextInfo == null ? (_TextInfo = new System.Globalization.CultureInfo(AppSettings.CultureName, false).TextInfo) : _TextInfo);
            }
        }

        /// <summary>
        /// combine all path, append BaseUrl as prefix and return full qualified URL. 
        /// </summary>
        /// <param name="path">path to combine</param>
        public static string MapUrl(params string[] path)
        {
            return String.Format("{0}{1}", AppSettings.BaseUrl, System.IO.Path.Combine(path));
        }

        #region Extension Methods
     
        /// <summary>
        /// convert string to SentenceCase
        /// </summary>
        public static string ToSentenceCase(this string str)
        {
            return TextInfo.ToTitleCase(str);
        }


        #endregion

       
    }

    public static class AppSettings
    {
        /// <summary>
        /// retunrs BaseUrl defined in web.config
        /// </summary>
        public static string BaseUrl { get { return GetAppSettingValue("BaseUrl"); } }

        /// <summary>
        /// retunrs CultureName defined in web.config
        /// </summary>
        public static string CultureName { get { return GetAppSettingValue("CultureName"); } }

        /// <summary>
        /// retunrs DefaultDateFormat defined in web.config
        /// </summary>
        public static string DefaultDateFormat { get { return GetAppSettingValue("DefaultDateFormat"); } }

        private static string GetAppSettingValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }

}