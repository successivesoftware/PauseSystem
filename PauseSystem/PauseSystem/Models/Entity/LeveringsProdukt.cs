using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class LeveringsProdukt : BaseEntity
    {
        public int Id { get; set; }
        public int LeveringsId { get; set; }
        public int ProduktNr { get; set; }
        public double SalgsPris { get; set; }
        public double KostPris { get; set; }
        public double GrossistPris { get; set; }
        public Nullable<double> Dekort { get; set; }
        public int Antal { get; set; }
        public string PrintLabel { get; set; }
        public Nullable<double> Provision { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<bool> IsDelivered { get; set; }
        public Nullable<int> DeliveredAntal { get; set; }
        public Nullable<int> DeliveryProductCountDiffReasonId { get; set; }
        public Nullable<int> GrøntkasseId { get; set; }

        public virtual Produkt Produkt { get; set; }
        public virtual TurLevering TurLevering { get; set; }


    }
}
