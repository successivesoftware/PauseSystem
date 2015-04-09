using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AdresserMap : EntityTypeConfiguration<Adresser>
    {
        public AdresserMap()
        {
            // Primary Key
            this.HasKey(t => t.AdresseId);

            // Properties
            this.Property(t => t.Adresse)
                .HasMaxLength(450);

            this.Property(t => t.PostNr)
                .HasMaxLength(450);

            this.Property(t => t.City)
                .HasMaxLength(450);

            this.Property(t => t.Kommentar)
                .HasMaxLength(1050);

            this.Property(t => t.Etage)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Adresser");
            this.Property(t => t.AdresseId).HasColumnName("AdresseId");
            this.Property(t => t.KundeNr).HasColumnName("KundeNr");
            this.Property(t => t.Adresse).HasColumnName("Adresse");
            this.Property(t => t.PostNr).HasColumnName("PostNr");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Kommentar).HasColumnName("Kommentar");
            this.Property(t => t.X).HasColumnName("X");
            this.Property(t => t.Y).HasColumnName("Y");
            this.Property(t => t.DeliveryTime).HasColumnName("DeliveryTime");
            this.Property(t => t.CommentVisibleTill).HasColumnName("CommentVisibleTill");
            this.Property(t => t.Etage).HasColumnName("Etage");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
        }
    }
}
