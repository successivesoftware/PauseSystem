using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ExternFragtMap : EntityTypeConfiguration<ExternFragt>
    {
        public ExternFragtMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ExternFragt");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
