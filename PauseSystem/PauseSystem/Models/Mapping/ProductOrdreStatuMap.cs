using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ProductOrdreStatuMap : EntityTypeConfiguration<ProductOrdreStatu>
    {
        public ProductOrdreStatuMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.prioritet });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Navn)
                .HasMaxLength(50);

            this.Property(t => t.prioritet)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ProductOrdreStatus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Navn).HasColumnName("Navn");
            this.Property(t => t.prioritet).HasColumnName("prioritet");
        }
    }
}
