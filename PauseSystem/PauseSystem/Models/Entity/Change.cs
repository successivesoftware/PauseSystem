using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Change : BaseEntity
    {
        
        public int KundeId { get; set; }
        public int OldAdresseId { get; set; }
        public Nullable<int> NewAdresseId { get; set; }
        public System.DateTime OldDate { get; set; }
        public Nullable<System.DateTime> NewDate { get; set; }
        public int OldProduktId { get; set; }
        public Nullable<int> NewProduktId { get; set; }
        public string OldRute { get; set; }
        public string NewRute { get; set; }
        public int OldAntal { get; set; }
        public Nullable<int> NewAntal { get; set; }
        public int Status { get; set; }
        public Nullable<int> Week { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> MedarbejderId { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
