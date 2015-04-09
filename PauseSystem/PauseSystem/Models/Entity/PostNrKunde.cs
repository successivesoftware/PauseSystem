using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class PostNrKunde : BaseEntity
    {
        
        public int PostNrIntervalId { get; set; }
        public int KundeId { get; set; }
        public int Ugedag { get; set; }
    }
}
