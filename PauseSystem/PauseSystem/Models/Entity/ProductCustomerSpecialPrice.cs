using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ProductCustomerSpecialPrice : BaseEntity
    {
        
        public int ProductNr { get; set; }
        public int CustomerId { get; set; }
        public int Antal { get; set; }
        public double Pris { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int MedarbejderId { get; set; }
    }
}
