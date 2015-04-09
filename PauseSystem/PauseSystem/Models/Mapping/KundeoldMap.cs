using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class KundeoldMap : EntityTypeConfiguration<Kundeold>
    {
        public KundeoldMap()
        {
            // Primary Key
            this.HasKey(t => new { t.KundeNr, t.CreatedDate, t.OrdreKilde });

            // Properties
            this.Property(t => t.KundeNr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Navn)
                .HasMaxLength(500);

            this.Property(t => t.Kontakt)
                .HasMaxLength(250);

            this.Property(t => t.Telefon)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(250);

            this.Property(t => t.KundeType)
                .HasMaxLength(50);

            this.Property(t => t.OrdreKilde)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Kundeold");
            this.Property(t => t.KundeNr).HasColumnName("KundeNr");
            this.Property(t => t.Navn).HasColumnName("Navn");
            this.Property(t => t.Kontakt).HasColumnName("Kontakt");
            this.Property(t => t.Telefon).HasColumnName("Telefon");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.KundeType).HasColumnName("KundeType");
            this.Property(t => t.FaktureringsAdresseId).HasColumnName("FaktureringsAdresseId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.OrdreKilde).HasColumnName("OrdreKilde");
            this.Property(t => t.Betalingsbetingelse).HasColumnName("Betalingsbetingelse");
            this.Property(t => t.Branche).HasColumnName("Branche");
            this.Property(t => t.VirksomhedsForm).HasColumnName("VirksomhedsForm");
        }
    }
}
