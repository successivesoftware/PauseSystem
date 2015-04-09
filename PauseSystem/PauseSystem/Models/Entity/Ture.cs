using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class Ture : BaseEntity
    {
        public Nullable<int> Year { get; set; }
        public Nullable<int> Week { get; set; }
        public Nullable<int> DayOfWeek { get; set; }
        public int TurId { get; set; }
        public Nullable<bool> Edit { get; set; }
        public byte[] Leveringer { get; set; }
        public Nullable<int> PackedBy { get; set; }
        public Nullable<int> CheckedBy { get; set; }
        public Nullable<System.DateTime> StartTid { get; set; }
        public Nullable<int> Chauffør { get; set; }
        public Nullable<int> StartAdress { get; set; }
        public Nullable<int> EndAdress { get; set; }
        public Nullable<bool> DoPrint { get; set; }
        public Nullable<int> EditBy { get; set; }
        public Nullable<System.DateTime> LastEdit { get; set; }
        
        public Nullable<int> Car { get; set; }
        public Nullable<double> Km { get; set; }
        public Nullable<bool> Packed { get; set; }
        public Nullable<System.DateTime> Dato { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> AntalLeveringer { get; set; }
        public Nullable<int> AntalProdukter { get; set; }
        public bool AddToRoute { get; set; }
        public Nullable<int> ExternFragtChauffør { get; set; }
    }
}
