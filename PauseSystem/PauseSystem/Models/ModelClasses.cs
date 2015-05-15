using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PauseSystem.Models
{
    public class LeveringModel
    {
        public LeveringModel()
        {
            CustomerDeliveryAdresses = new List<CustomerDeliveryAdresses>();
            
        }

        public string KundeName { get; set; }
        public int KundeId { get; set; }

        [Required]
        [Display(Name="Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public IList<CustomerDeliveryAdresses> CustomerDeliveryAdresses { get; set; }
    }
}