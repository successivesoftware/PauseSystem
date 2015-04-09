using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ProductOrdreStatu : BaseEntity
    {
        
        public string Navn { get; set; }
        public int prioritet { get; set; }
    }
}
