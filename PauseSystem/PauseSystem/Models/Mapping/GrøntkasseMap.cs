using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class GrøntkasseMap : EntityTypeConfiguration<Grøntkasse>
    {
        public GrøntkasseMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Grøntkasse");
            this.Property(t => t.GrøntKasseNr).HasColumnName("GrøntKasseNr");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.GProduktNummer).HasColumnName("GProduktNummer");
            this.Property(t => t.GPSalgsPris).HasColumnName("GPSalgsPris");
            this.Property(t => t.Base).HasColumnName("Base");
            this.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
