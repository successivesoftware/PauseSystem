using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class TurLevering : BaseEntity
    {
        
        public int KundeId { get; set; }
        public int TurId { get; set; }
        public int AdresseId { get; set; }
        public int Zindex { get; set; }
        public Nullable<System.DateTime> LeveringsTid { get; set; }
        public Nullable<bool> PrintPakkeListe { get; set; }
        public Nullable<int> SkipReasonId { get; set; }
        public Nullable<int> AbonnementId { get; set; }

        public virtual Adresser Adresser { get; set; }
    }
}
