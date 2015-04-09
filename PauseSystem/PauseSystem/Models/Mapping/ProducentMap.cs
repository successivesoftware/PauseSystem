using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ProducentMap : EntityTypeConfiguration<Producent>
    {
        public ProducentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Navn)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Producent");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Navn).HasColumnName("Navn");
        }
    }
}
