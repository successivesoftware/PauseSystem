using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Dekorter : BaseEntity
    {
        public int LeveringsId { get; set; }
        public Nullable<int> MedarbejderId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public double Dekort { get; set; }
        
    }
}
