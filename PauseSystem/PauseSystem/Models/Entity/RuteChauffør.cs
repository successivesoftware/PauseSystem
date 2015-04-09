using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class RuteChauffør : BaseEntity
    {
        public int Rute { get; set; }
        public Nullable<int> Chauffør { get; set; }
    }
}
