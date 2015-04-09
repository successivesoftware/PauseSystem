using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class BrancheMap : EntityTypeConfiguration<Branche>
    {
        public BrancheMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Navn)
                .HasMaxLength(450);

            // Table & Column Mappings
            this.ToTable("Branche");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Navn).HasColumnName("Navn");
        }
    }
}
