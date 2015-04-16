using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PauseSystem.Helpers
{
    public static class PauseHelper
    {

        public const string CultureName = "en-US";

        private static TextInfo _TextInfo;
        public static TextInfo TextInfo
        {
            get
            {
                return (_TextInfo == null ? (_TextInfo = new System.Globalization.CultureInfo(CultureName, false).TextInfo) : _TextInfo);
            }
        }

        #region Extension Methods

        public static string ToSentenceCase(this string str)
        {
            return TextInfo.ToTitleCase(str);
        }

        #endregion
    }
}