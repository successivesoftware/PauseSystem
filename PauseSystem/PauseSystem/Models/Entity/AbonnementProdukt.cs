using System;
using System.Collections.Generic;

namespace PauseSystem.Models.Entity
{
    public partial class AbonnementProdukt : BaseEntity
    {

        public int AbonnementId { get; set; }
        public int ProduktNr { get; set; }
        public System.DateTime StartDato { get; set; }
        public System.DateTime SlutDato { get; set; }
        public int Antal { get; set; }
        public Interval Interval { get; set; }
        public Nullable<int> Ophør { get; set; }
        public string PrintLabel { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

        public virtual ICollection<AbbonnementProduktPause> AbbonnementProduktPauses { get; set; }
        public virtual ICollection<AbonnementProduktChange> AbonnementProduktChanges { get; set; }

        public virtual Produkt Produkt { get; set; }
        public virtual Abonnementer Abonnement { get; set; }

        #region Databinding

        //public string DbdgOmsæt
        //{
        //    get
        //    {
        //        if (Produkt != null)
        //        {
        //            double salg = SpecialPris > 0 ? SpecialPris : Produkt.SalgsPris;

        //            if (Abonnement.Kunde != null && Abonnement.Kunde.KundeType == KundeType.PartnerService)
        //                salg = Produkt.GrossistPris;
        //            double linjeOmsæt = Antal * salg;
        //            double linjeDb = Antal * salg - Antal * Produkt.KostPris;
        //            double linjeDg = ((salg - Produkt.KostPris) / salg) * 100;
        //            return " Linje\t DB : " + linjeDb.ToString("F") + " kr. \t - DG : " + linjeDg.ToString("F") + "%\t - Omsæt : " + linjeOmsæt.ToString("F") + " kr.";

        //        }
        //        return "Fejl";
        //    }
        //}
        public bool IsActive(DateTime Date)
        {
            if (this.StartDato.Date <= Date.Date && this.SlutDato.Date >= Date.Date)
                return true;
            return false;
        }
        public bool OnPause(DateTime Date)
        {
            foreach (var p in this.AbbonnementProduktPauses)
            {
                if (Date.Date >= p.Start.Date && Date.Date <= p.Slut.Date)
                    return true;
            }
            return false;

        }
        public bool HasFuturePause(DateTime dateTime)
        {
            bool ReturnValue = false;

            foreach (var abonnementProduktPause in this.AbbonnementProduktPauses)
            {
                if (abonnementProduktPause.Slut.Date >= dateTime.Date)
                    ReturnValue = true;
            }

            return ReturnValue;
        }
        //public System.Windows.Media.Brush GetActiveColor(DateTime dt)
        //{
        //    System.Windows.Media.Brush returnColor = System.Windows.Media.Brushes.Tomato;
        //    if (IsActive(dt))
        //    {
        //        returnColor = SystemColors.WindowBrush;
        //        if (HasFuturePause(dt))
        //        {
        //            returnColor = System.Windows.Media.Brushes.Green;
        //        }
        //        if (this.OnPause(dt))
        //        {
        //            returnColor = System.Windows.Media.Brushes.Yellow;
        //        }
        //    }
        //    else
        //    {
        //        if (this.StartDato.Date > dt.Date)
        //        {
        //            returnColor = System.Windows.Media.Brushes.LightBlue;
        //        }
        //    }
        //    return returnColor;
        //}
        #endregion
    }
}
