using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Abonnementer : BaseEntity
    {
        
        public Nullable<int> Ugedag { get; set; }
        public Nullable<int> RuteNr { get; set; }
        public Nullable<int> RuteIndex { get; set; }
        public Nullable<int> LeveringsAdresseId { get; set; }
        public Nullable<System.DateTime> DeliveryTime { get; set; }
        public Nullable<int> KundeId { get; set; }
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
        public Nullable<bool> PrintPakkeList { get; set; }
        public Nullable<System.DateTime> PrintPakkeDato { get; set; }
    }
}
