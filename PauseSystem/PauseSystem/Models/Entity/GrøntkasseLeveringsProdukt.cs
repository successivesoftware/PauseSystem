using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class GrøntkasseLeveringsProdukt : BaseEntity
    {
        
        public int GrøntkasseLeveringsId { get; set; }
        public int Antal { get; set; }
        public int ProduktNr { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
