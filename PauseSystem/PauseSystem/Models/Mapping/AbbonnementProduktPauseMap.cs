using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbbonnementProduktPauseMap : EntityTypeConfiguration<AbbonnementProduktPause>
    {
        public AbbonnementProduktPauseMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AbbonnementProduktPause");
            this.Property(t => t.AbonnementProduktId).HasColumnName("AbonnementProduktId");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Start).HasColumnName("Start");
            this.Property(t => t.Slut).HasColumnName("Slut");
        }
    }
}
