using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbonnementOphør : BaseEntity
    {
        public string Grund { get; set; }
        public int Nøgle { get; set; }
    }
}
