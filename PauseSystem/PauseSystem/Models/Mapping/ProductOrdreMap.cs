using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ProductOrdreMap : EntityTypeConfiguration<ProductOrdre>
    {
        public ProductOrdreMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductOrdre");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.KundeNr).HasColumnName("KundeNr");
            this.Property(t => t.AdresseId).HasColumnName("AdresseId");
            this.Property(t => t.OrdreNr).HasColumnName("OrdreNr");
            this.Property(t => t.Db).HasColumnName("Db");
            this.Property(t => t.OrdreStatus).HasColumnName("OrdreStatus");
            this.Property(t => t.ChaufførId).HasColumnName("ChaufførId");
            this.Property(t => t.SælgerId).HasColumnName("SælgerId");
            this.Property(t => t.Produkter).HasColumnName("Produkter");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.SelectedStatus).HasColumnName("SelectedStatus");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
        }
    }
}
