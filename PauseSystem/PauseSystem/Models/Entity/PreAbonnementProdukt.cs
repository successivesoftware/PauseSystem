using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PauseSystem.Models.Entity
{
    public class PreAbonnementProdukt : BaseEntity
    {
        [Required]
        [Display(Name = "Address")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Address field is required.")]
        public int AddressId { get; set; }
        [Required]
        [Display(Name = "Product")]
        public int ProduktNr { get; set; }
        [Required]
        [Display(Name = "DayOfWeek")]
        public int DayOfWeek { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        [Required]
        [Display(Name = "Antal")]
        public int Antal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Interval { get; set; }


        public virtual Adresser Adresser { get; set; }
        public virtual Produkt Produkt { get; set; }
        public virtual TurLevering TurLevering { get; set; }
    }
}