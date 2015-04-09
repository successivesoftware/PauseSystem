using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ProductOrdre : BaseEntity
    {
        
        public Nullable<int> KundeNr { get; set; }
        public Nullable<int> AdresseId { get; set; }
        public Nullable<int> OrdreNr { get; set; }
        public Nullable<double> Db { get; set; }
        public string OrdreStatus { get; set; }
        public Nullable<int> ChaufførId { get; set; }
        public Nullable<int> SælgerId { get; set; }
        public string Produkter { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> SelectedStatus { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
    }
}
