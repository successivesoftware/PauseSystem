using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbonnementChange : BaseEntity
    {
        
        public int AbonnementId { get; set; }
        public int Antal { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int MadeById { get; set; }
        public int ProduktNumber { get; set; }
        public System.DateTime Date { get; set; }
    }
}
