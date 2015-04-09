using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class PriserMap : EntityTypeConfiguration<Priser>
    {
        public PriserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.KundeNr, t.ProduktNr });

            // Properties
            this.Property(t => t.KundeNr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProduktNr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Priser");
            this.Property(t => t.KundeNr).HasColumnName("KundeNr");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktNr");
            this.Property(t => t.SalgsPris).HasColumnName("SalgsPris");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
        }
    }
}
