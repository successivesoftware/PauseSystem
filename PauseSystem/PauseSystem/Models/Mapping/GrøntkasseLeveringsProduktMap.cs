using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class GrøntkasseLeveringsProduktMap : EntityTypeConfiguration<GrøntkasseLeveringsProdukt>
    {
        public GrøntkasseLeveringsProduktMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("GrøntkasseLeveringsProdukt", "u1000756_FrugtTest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GrøntkasseLeveringsId).HasColumnName("GrøntkasseLeveringsId");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktNr");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
