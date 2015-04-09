using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class DelivereyProdutDiffMap : EntityTypeConfiguration<DelivereyProdutDiff>
    {
        public DelivereyProdutDiffMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DeliveryProductDiffReason)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("DelivereyProdutDiff", "u1000756_FrugtTest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DeliveryProductDiffReason).HasColumnName("DeliveryProductDiffReason");
        }
    }
}
