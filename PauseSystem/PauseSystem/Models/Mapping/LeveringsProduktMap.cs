using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class LeveringsProduktMap : EntityTypeConfiguration<LeveringsProdukt>
    {
        public LeveringsProduktMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PrintLabel)
                .HasMaxLength(450);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("LeveringsProdukt");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LeveringsId).HasColumnName("LeveringsId");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktId");
            this.Property(t => t.SalgsPris).HasColumnName("SalgsPris");
            this.Property(t => t.KostPris).HasColumnName("KostPris");
            this.Property(t => t.GrossistPris).HasColumnName("GrossistPris");
            this.Property(t => t.Dekort).HasColumnName("Dekort");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.PrintLabel).HasColumnName("PrintLabel");
            this.Property(t => t.Provision).HasColumnName("Provision");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.IsDelivered).HasColumnName("IsDelivered");
            this.Property(t => t.DeliveredAntal).HasColumnName("DeliveredAntal");
            this.Property(t => t.DeliveryProductCountDiffReasonId).HasColumnName("DeliveryProductCountDiffReasonId");
            this.Property(t => t.GrøntkasseId).HasColumnName("GrøntkasseId");

            this.HasRequired(x => x.TurLevering).WithMany().HasForeignKey(x => x.LeveringsId);
            this.HasRequired(x => x.Produkt).WithMany().HasForeignKey(x => x.ProduktNr);

           

        }
    }
}
