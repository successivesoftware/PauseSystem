using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Abonnementer : BaseEntity
    {

        public DayOfWeek Ugedag { get; set; }
        public Nullable<int> RuteNr { get; set; }
        public int RuteIndex { get; set; }
        public int LeveringsAdresseId { get; set; }
        public Nullable<System.DateTime> DeliveryTime { get; set; }
        public int KundeId { get; set; }
        public Nullable<int> KundeNr { get; set; }
        public Nullable<System.DateTime> StartDato { get; set; }
        public Nullable<System.DateTime> SlutDato { get; set; }
        public Nullable<int> Antal { get; set; }
        public Nullable<System.DateTime> StartPause { get; set; }
        public Nullable<System.DateTime> EndPause { get; set; }
        public Nullable<int> Ophør { get; set; }
        public Nullable<int> ProduktNr { get; set; }
        public Nullable<int> Interval { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool PrintPakkeList { get; set; }
        public Nullable<System.DateTime> PrintPakkeDato { get; set; }

        public virtual AbonnementRute AbonnementRute { get; set; }
        public virtual ICollection<AbonnementProdukt> AbonnementProdukts { get; set; }
        public virtual ICollection<AbonnementChange> AbonnementChanges { get; set; }

        public virtual Adresser LeveringsAdresse { get; set; }
        public virtual Kunde Kunde { get; set; }



    }
}
