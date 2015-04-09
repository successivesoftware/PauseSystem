using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class GrøntKasseLevering : BaseEntity
    {
        public int LeveringsProduktId { get; set; }
        public int GrøntkasseNr { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
