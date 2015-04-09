using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbonnementOphørMap : EntityTypeConfiguration<AbonnementOphør>
    {
        public AbonnementOphørMap()
        {
            // Primary Key
            this.HasKey(t => t.Nøgle);

            // Properties
            this.Property(t => t.Grund)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("AbonnementOphør");
            this.Property(t => t.Grund).HasColumnName("Grund");
            this.Property(t => t.Nøgle).HasColumnName("Nøgle");
        }
    }
}
