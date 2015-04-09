using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class PriMap : EntityTypeConfiguration<Pri>
    {
        public PriMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ProduktNr, t.KundeId, t.Id });

            // Properties
            this.Property(t => t.ProduktNr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.KundeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("Pris");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktNr");
            this.Property(t => t.SalgsPris).HasColumnName("SalgsPris");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.MedarbejderId).HasColumnName("MedarbejderId");
            this.Property(t => t.Aktiv).HasColumnName("Aktiv");
        }
    }
}
