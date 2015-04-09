using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ProduktOld : BaseEntity
    {
        public int ProduktNr { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public Nullable<int> stk { get; set; }
        public Nullable<double> KostPris { get; set; }
        public Nullable<double> SalgsPris { get; set; }
        public Nullable<double> GrossistPris { get; set; }
        public int ProduktGruppeId { get; set; }
        public Nullable<int> Leverandør { get; set; }
        public Nullable<int> Volume { get; set; }
        public Nullable<double> Provision { get; set; }
        public Nullable<double> Weight { get; set; }
        public string Externt { get; set; }
        public Nullable<int> ProduktUnderGruppeId { get; set; }
    }
}
