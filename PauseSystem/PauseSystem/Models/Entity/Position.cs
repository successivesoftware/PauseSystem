using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Position : BaseEntity
    {
        public int RouteId { get; set; }
        public Nullable<System.DateTime> Dato { get; set; }
        public Nullable<double> X { get; set; }
        public Nullable<double> y { get; set; }
        
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
