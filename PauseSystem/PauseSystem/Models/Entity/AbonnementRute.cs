using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbonnementRute 
    {
        public int RuteId { get; set; }
     //   public Nullable<int> DayOfWeek { get; set; }

        public DayOfWeek Ugedag { get; set; }

        public Nullable<int> Chauffør { get; set; }
        public Nullable<int> StartAdresse { get; set; }
        public Nullable<int> AbIndex { get; set; }
        public Nullable<System.DateTime> StartTid { get; set; }
        public string Name { get; set; }
        public bool Printes { get; set; }
        public int Uid { get; set; }
        public Nullable<int> EndAdresse { get; set; }
        public Nullable<int> Bil { get; set; }
        public bool AddToRoute { get; set; }
        public bool Ophørt { get; set; }
    }
}
