using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbbonnementProduktPause : BaseEntity
    {
        public int AbonnementProduktId { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Slut { get; set; }
    }
}
