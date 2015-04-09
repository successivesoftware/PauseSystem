using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ProduktUndergruppe : BaseEntity
    {
        
        public int ParentId { get; set; }
        public string Navn { get; set; }
    }
}
