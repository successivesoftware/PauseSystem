using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Adresser 
    {
        public int AdresseId { get; set; }
        public Nullable<int> KundeNr { get; set; }
        public string Adresse { get; set; }
        public string PostNr { get; set; }
        public string City { get; set; }
        public string Kommentar { get; set; }
        public Nullable<double> X { get; set; }
        public Nullable<double> Y { get; set; }
        public Nullable<double> DeliveryTime { get; set; }
        public Nullable<System.DateTime> CommentVisibleTill { get; set; }
        public string Etage { get; set; }
        public Nullable<int> KundeId { get; set; }
    }
}
