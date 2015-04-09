using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Grøntkasse : BaseEntity
    {
        public Nullable<int> GrøntKasseNr { get; set; }
        public Nullable<int> Antal { get; set; }
        public Nullable<int> GProduktNummer { get; set; }
        public Nullable<double> GPSalgsPris { get; set; }
        public string Base { get; set; }
        
    }
}
