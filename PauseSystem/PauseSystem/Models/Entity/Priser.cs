using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Priser : BaseEntity
    {
        public int KundeNr { get; set; }
        public int ProduktNr { get; set; }
        public Nullable<double> SalgsPris { get; set; }
        public Nullable<int> KundeId { get; set; }
    }
}
