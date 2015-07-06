using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Levering : BaseEntity
    {
        public int Id { get; set; }
        public int WeekNr { get; set; }
        public int Year { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string KundeNr { get; set; }
        public string Produkt { get; set; }
        public string Adresse { get; set; }
        public string Pris { get; set; }
        public int Zindex { get; set; }
        public int Antal { get; set; }
        public bool IsOrdre { get; set; }
        public Nullable<System.DateTime> SenesteLeveringsTid { get; set; }
        public int RuteId { get; set; }
        public Nullable<System.DateTime> Leveret { get; set; }
        public Nullable<double> Dekort { get; set; }
        public string PrintLabel { get; set; }
        public Nullable<bool> PrintPakkeListe { get; set; }
        public Nullable<int> AbonnementId { get; set; }
    }
}
