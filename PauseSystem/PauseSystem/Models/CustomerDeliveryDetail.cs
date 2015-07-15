using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models
{
    public class CustomerDeliveryDetail
    {
        public CustomerDelivery CustomerDelivery { get; set; }
        public int AddressId { get; set; }
        public DateTime Date { get; set; }
    }
}