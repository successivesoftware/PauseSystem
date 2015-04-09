using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class GrøntKasseLeveringMap : EntityTypeConfiguration<GrøntKasseLevering>
    {
        public GrøntKasseLeveringMap()
        {
            // Primary Key
            this.HasKey(t => t.LeveringsProduktId);

            // Properties
            this.Property(t => t.LeveringsProduktId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("GrøntKasseLevering", "u1000756_FrugtTest");
            this.Property(t => t.LeveringsProduktId).HasColumnName("LeveringsProduktId");
            this.Property(t => t.GrøntkasseNr).HasColumnName("GrøntkasseNr");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
