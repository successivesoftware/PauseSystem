using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Extensions
{
    public static class ProductExtensions
    {
        private const string _thumbFolder = "Web-Thumb-170x170/";
        private const string _webfolder = "Web-600x600/";
        private const string _domain = "billedbank.firmafrugt.com:8080/";
        public static string ThumbUrl(this Produkt p)
        {
            if (p.Producent != null)
                return _domain + p.Producent.Navn + _thumbFolder + p.UrlName();
            return string.Empty;

        }
        public static string ImageUrl(this Produkt p)
        {
            if (p.Producent != null)
                return _domain + p.Producent.Navn + _webfolder + p.UrlName();
            return string.Empty;
        }
        public static string UrlName(this Produkt p)
        {

            var urlname = Regex.Replace(p.Navn, @"[^A-Za-z0-9_\.~æøåÆØÅ]+", "_");
            if (urlname.EndsWith("_"))
                urlname = urlname.Substring(0, urlname.Length - 1);
            return urlname + ".jpg";

        }

    }
}