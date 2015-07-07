using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PauseSystem.Models.Mapping
{
    public class PreAbonnemetProduktMap : EntityTypeConfiguration<PreAbonnementProdukt>
    {
        public PreAbonnemetProduktMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            //properties
            this.Property(t => t.CreatedBy).HasMaxLength(100);
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            ToTable("PreAbonnementProdukt");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.DayOfWeek).HasColumnName("Ugedag");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktNr");
            this.Property(t => t.Interval).HasColumnName("Interval");

            this.HasRequired(x => x.Adresser).WithMany().HasForeignKey(x => x.AddressId);
            this.HasRequired(x => x.Produkt).WithMany().HasForeignKey(x => x.ProduktNr);
            this.HasRequired(x => x.TurLevering).WithMany().HasForeignKey(x => x.AddressId);
        }
    }
}