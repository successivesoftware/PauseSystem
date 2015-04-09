using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Kunde : BaseEntity
    {
        public int KundeNr { get; set; }
        public string Navn { get; set; }
        public string Kontakt { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int KundeType { get; set; }
        public Nullable<int> FaktureringsAdresseId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int OrdreKilde { get; set; }
        public Nullable<int> Betalingsbetingelse { get; set; }
        public Nullable<int> Branche { get; set; }
        public Nullable<int> VirksomhedsForm { get; set; }
        
        public Nullable<int> SugerCrmNummer { get; set; }
        public string AfmeldingsPass { get; set; }
        public Nullable<System.TimeSpan> ÅbningsTid { get; set; }
        public Nullable<System.TimeSpan> LukkeTid { get; set; }
    }
}
