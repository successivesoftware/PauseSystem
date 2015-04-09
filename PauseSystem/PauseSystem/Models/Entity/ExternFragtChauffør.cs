using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class ExternFragtChauffør : BaseEntity
    {
        
        public int ExternFragtId { get; set; }
        public string Navn { get; set; }
        public string Telefon { get; set; }
    }
}
