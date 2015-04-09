using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class VersionLogMap : EntityTypeConfiguration<VersionLog>
    {
        public VersionLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Version)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("VersionLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Version).HasColumnName("Version");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
