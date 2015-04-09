using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ProduktUndergruppeMap : EntityTypeConfiguration<ProduktUndergruppe>
    {
        public ProduktUndergruppeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.ParentId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ParentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Navn)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("ProduktUndergruppe");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Navn).HasColumnName("Navn");
        }
    }
}
