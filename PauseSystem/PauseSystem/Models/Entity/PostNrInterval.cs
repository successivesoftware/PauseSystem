using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class PostNrInterval : BaseEntity
    {
        
        public int Fra { get; set; }
        public int Til { get; set; }
        public bool Mandag { get; set; }
        public bool Tirsdag { get; set; }
        public bool Onsdag { get; set; }
        public bool Torsdag { get; set; }
        public bool Fredag { get; set; }
    }
}
