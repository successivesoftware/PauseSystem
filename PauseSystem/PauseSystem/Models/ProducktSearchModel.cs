using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PauseSystem.Models
{
    public class ProducktSearchModel
    {
        public string OnSelect { get; set; }
        public string ContainerId { get; set; }
        public ProduktSearchResult[] Results { get; set; }
    }

    public class ProduktSearchResult
    {
        public int Id { get; set; }

        [Required]
        public int ProducktNr { get; set; }
        public string Icon { get; set; }
        public string ProduktName { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Used for Autocompleter
        /// </summary>
        public string name
        {
            get
            {
                return String.Format("<div><img src='{0}' style='max-height:50px;' /> <strong> {1} </strong> <label class='label label-warning' style='margin:left:10px;'> {2} <label> </div>", 
                    this.Icon, this.ProduktName, this.Price);
            }
        }
     

    }
}