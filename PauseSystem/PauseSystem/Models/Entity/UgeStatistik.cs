using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class UgeStatistik : BaseEntity
    {
        
        public int Year { get; set; }
        public int Week { get; set; }
        public int KundeId { get; set; }
        public Nullable<double> Omsæt { get; set; }
        public Nullable<double> Db { get; set; }
        public Nullable<double> Dg { get; set; }
    }
}
