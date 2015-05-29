using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbonnementProduktMap : EntityTypeConfiguration<AbonnementProdukt>
    {
        public AbonnementProduktMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AbonnementProdukt");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AbonnementId).HasColumnName("AbonnementId");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktNr");
            this.Property(t => t.StartDato).HasColumnName("StartDato");
            this.Property(t => t.SlutDato).HasColumnName("SlutDato");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.Interval).HasColumnName("Interval");
            this.Property(t => t.Ophør).HasColumnName("Ophør");
            this.Property(t => t.PrintLabel).HasColumnName("PrintLabel");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.HasRequired(p => p.Abonnement).WithMany().HasForeignKey(p => p.AbonnementId);
        }
    }
}
