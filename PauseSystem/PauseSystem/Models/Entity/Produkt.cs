using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Produkt : BaseEntity
    {
        public int ProduktNr { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public Nullable<int> stk { get; set; }
        public double KostPris { get; set; }
        public double SalgsPris { get; set; }
        public double GrossistPris { get; set; }
        public int ProduktGruppeId { get; set; }
        public Nullable<int> Leverandør { get; set; }
        public Nullable<int> Volume { get; set; }
        public Nullable<double> Provision { get; set; }
        /// <summary>
        /// Weight in KG
        /// </summary>
        public Nullable<double> Weight { get; set; }
        public string Externt { get; set; }
        public Nullable<int> ProduktUnderGruppeId { get; set; }
        
        public Nullable<bool> Active { get; set; }
        public Nullable<int> FølgeProdukt { get; set; }
        public string ManufactureNumber { get; set; }
        public string LabelText { get; set; }
        public Nullable<bool> SkalIkkeFaktureres { get; set; }
        public bool LeveringMåIkkeSlettes { get; set; }
        public string Url { get; set; }
        public bool Prisliste { get; set; }
        public Nullable<int> ProducentId { get; set; }
    }
}
