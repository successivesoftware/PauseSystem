using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models
{
    public class CustomerDelivery
    {
        public int Antal { get; set; }

        public int VareNr { get; set; }

        public string Beskrivelse { get; set; }

        public double? Pris { get; set; }

        public double? SampletPris { get; set; }


    }
}