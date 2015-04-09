using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Medarbejdere : BaseEntity
    {
        
        public string Fornavn { get; set; }
        public string EfterNavn { get; set; }
        public Nullable<bool> Aktiv { get; set; }
        public string Password { get; set; }
        public int Rolle { get; set; }
        public string PrivatMobil { get; set; }
        public string MsMobil { get; set; }
        public Nullable<double> Timeløn { get; set; }
        public string SugarUser { get; set; }
        public string SugarPassword { get; set; }
        public Nullable<int> OrdreKilde { get; set; }
        public string PausePassword { get; set; }
        public Nullable<int> Extern { get; set; }
    }
}
