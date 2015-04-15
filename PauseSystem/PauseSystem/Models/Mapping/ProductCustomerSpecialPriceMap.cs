using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ProductCustomerSpecialPriceMap : EntityTypeConfiguration<ProductCustomerSpecialPrice>
    {
        public ProductCustomerSpecialPriceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, ProductNr = t.ProductNr, t.CustomerId, t.Antal, t.Pris, t.FromDate, t.ToDate, t.CreatedDate, t.MedarbejderId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ProductNr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CustomerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Antal)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MedarbejderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ProductCustomerSpecialPrices", "u1000756_FrugtTest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductNr).HasColumnName("ProductId");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.Pris).HasColumnName("Pris");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.MedarbejderId).HasColumnName("MedarbejderId");
        }
    }
}
