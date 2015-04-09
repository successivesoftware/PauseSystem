using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Haendelse : BaseEntity
    {
        public int LeveringsId { get; set; }
        public string Hændelse { get; set; }
        public string Action { get; set; }
        public Nullable<int> MedarbejderId { get; set; }
    }
}
