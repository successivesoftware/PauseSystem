using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class DriverMessageMap : EntityTypeConfiguration<DriverMessage>
    {
        public DriverMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("DriverMessages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.PostedBy).HasColumnName("PostedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ReadBy).HasColumnName("ReadBy");
            this.Property(t => t.ReadAt).HasColumnName("ReadAt");
            this.Property(t => t.IsRead).HasColumnName("IsRead");
        }
    }
}
