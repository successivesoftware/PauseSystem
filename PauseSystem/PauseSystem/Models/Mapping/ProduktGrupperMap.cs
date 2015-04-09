using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ProduktGrupperMap : EntityTypeConfiguration<ProduktGrupper>
    {
        public ProduktGrupperMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Navn)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ProduktGrupper");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Navn).HasColumnName("Navn");
            this.Property(t => t.PakkelistePrintesAlene).HasColumnName("PakkelistePrintesAlene");
            this.Property(t => t.ListerPrintesSammenForDage).HasColumnName("ListerPrintesSammenForDage");
            this.Property(t => t.MaxPrDelivery).HasColumnName("MaxPrDelivery");
        }
    }
}
