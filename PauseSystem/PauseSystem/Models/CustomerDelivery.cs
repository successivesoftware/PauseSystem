using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models
{
    public class CustomerDeliveryAdresses
    {
        public int AdressId { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public List<CustomerDeliveryWeek> DeliveryWeeks { get; set; }

    }


    public class CustomerDeliveryWeek
    {
        public int Week { get; set; }
        public List<CustomerDeliverDates> DeliverDates { get; set; }
    }

    public class CustomerDeliverDates
    {
        public string DateString { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public List<CustomerDelivery> Deliveries { get; set; }
    }

    public class CustomerDelivery
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int ProduktNumber { get; set; }
        public string Produkt { get; set; }
        public double Pris { get; set; }
    }
}