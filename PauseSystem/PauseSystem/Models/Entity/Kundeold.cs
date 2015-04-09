using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Kundeold : BaseEntity
    {
        public int KundeNr { get; set; }
        public string Navn { get; set; }
        public string Kontakt { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string KundeType { get; set; }
        public Nullable<int> FaktureringsAdresseId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int OrdreKilde { get; set; }
        public Nullable<int> Betalingsbetingelse { get; set; }
        public Nullable<int> Branche { get; set; }
        public Nullable<int> VirksomhedsForm { get; set; }
    }
}
