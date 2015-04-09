using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Grossister : BaseEntity
    {
        
        public string Name { get; set; }
        public Nullable<int> KundeNr { get; set; }
    }
}
