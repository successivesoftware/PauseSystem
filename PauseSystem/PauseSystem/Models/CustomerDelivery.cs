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

        public static CustomerDeliveryAdresses CreateInstance(LeveringsProdukt levering)
        {
            return new CustomerDeliveryAdresses()
            {
                Adress = levering.TurLevering.Adresser.Adresse + " " + levering.TurLevering.Adresser.Etage,
                AdressId = levering.TurLevering.AdresseId,
                City = levering.TurLevering.Adresser.City,
                PostalCode = levering.TurLevering.Adresser.PostNr,
                DeliveryWeeks = new List<CustomerDeliveryWeek>() { CustomerDeliveryWeek.CreateInstance(levering) }
            };
        }

        public static CustomerDeliveryAdresses CreateInstance(PreAbonnementProdukt preAbonnement)
        {
            return new CustomerDeliveryAdresses()
            {
                Adress = preAbonnement.Adresser.Adresse,
                AdressId = preAbonnement.AddressId,
                City = preAbonnement.Adresser.City,
                PostalCode = preAbonnement.Adresser.PostNr,
                DeliveryWeeks = new List<CustomerDeliveryWeek>() { CustomerDeliveryWeek.CreateInstance(preAbonnement) }
            };
        }
    }

    public class CustomerDeliveryWeek
    {
        public int Week { get; set; }
        public List<CustomerDeliverDates> DeliverDates { get; set; }

        public static CustomerDeliveryWeek CreateInstance(LeveringsProdukt levering)
        {
            return new CustomerDeliveryWeek()
             {
                 Week = levering.TurLevering.Ture.Week,
                 DeliverDates = new List<CustomerDeliverDates>() { CustomerDeliverDates.CreateInstance(levering) }
             };
        }

        public static CustomerDeliveryWeek CreateInstance(PreAbonnementProdukt preAbonnement)
        {
            return new CustomerDeliveryWeek()
            {
                Week = Helpers.TimeTool.GetWeekNumber(preAbonnement.StartDate),
                DeliverDates = new List<CustomerDeliverDates>() { CustomerDeliverDates.CreateInstance(preAbonnement) }
            };
        }
    }

    public class CustomerDeliverDates
    {
        public string DateString { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public List<CustomerDelivery> Deliveries { get; set; }

        public static CustomerDeliverDates CreateInstance(LeveringsProdukt levering)
        {
            return new CustomerDeliverDates()
            {
                DayOfWeek = PauseSystem.Helpers.UIHelper.ToSentenceCase(System.Globalization.CultureInfo.GetCultureInfo("da-DK").DateTimeFormat.GetDayName(levering.TurLevering.Ture.Dato.DayOfWeek)),
                Date = levering.TurLevering.Ture.Dato,
                DateString = levering.TurLevering.Ture.Dato.ToShortDateString(),
                Deliveries = new List<CustomerDelivery> { CustomerDelivery.CreateInstance(levering) }
            };
        }

        public static CustomerDeliverDates CreateInstance(PreAbonnementProdukt preAbonnement)
        {
            return new CustomerDeliverDates()
            {
                DayOfWeek = PauseSystem.Helpers.UIHelper.ToSentenceCase(System.Globalization.CultureInfo.GetCultureInfo("da-DK").DateTimeFormat.GetDayName((DayOfWeek)(preAbonnement.DayOfWeek))),
                Date = preAbonnement.StartDate,
                DateString = preAbonnement.StartDate.ToShortDateString(),
                Deliveries = new List<CustomerDelivery> { CustomerDelivery.CreateInstance(preAbonnement) }
            };
        }
    }

    public class CustomerDelivery
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int ProduktNumber { get; set; }
        public string Produkt { get; set; }
        public double Pris { get; set; }
        public int IsPreAbonnement { get; set; }

        public static CustomerDelivery CreateInstance(LeveringsProdukt levering)
        {
            return new CustomerDelivery
            {
                Number = levering.Antal,
                Pris = levering.SalgsPris,
                Produkt = levering.Produkt.Navn,
                ProduktNumber = levering.ProduktNr,
                Id = levering.Id,
                IsPreAbonnement = 0
            };
        }

        public static CustomerDelivery CreateInstance(PreAbonnementProdukt preAbonnement)
        {

            return new CustomerDelivery
            {
                Number = preAbonnement.Antal,
                Pris = preAbonnement.Produkt.SalgsPris,
                Produkt = preAbonnement.Produkt.Navn,
                ProduktNumber = preAbonnement.ProduktNr,
                Id = preAbonnement.Id,
                IsPreAbonnement = 1
            };
        }
    }
}