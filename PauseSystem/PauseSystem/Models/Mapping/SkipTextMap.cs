using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class SkipTextMap : EntityTypeConfiguration<SkipText>
    {
        public SkipTextMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Text });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(850);

            // Table & Column Mappings
            this.ToTable("SkipText");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Text).HasColumnName("Text");
        }
    }
}
