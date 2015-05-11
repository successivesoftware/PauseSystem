using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models
{
    public class AutoCompleterInput
    {
        public string Query { get; set; }
        public object Parameter { get; set; }
        public int MinLength { get; set; }
        public string PlaceHolder { get; set; }
        public string Url { get; set; }
    }

    public class AutoCompleterResult
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public object ItemDescription { get; set; }
    }
}