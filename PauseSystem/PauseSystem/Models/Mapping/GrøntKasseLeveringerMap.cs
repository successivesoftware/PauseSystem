using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class GrøntKasseLeveringerMap : EntityTypeConfiguration<GrøntKasseLeveringer>
    {
        public GrøntKasseLeveringerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Week, t.Year, t.AdressId, t.RuteId, t.Leveringer });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Week)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Year)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AdressId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RuteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Leveringer)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("GrøntKasseLeveringer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.AdressId).HasColumnName("AdressId");
            this.Property(t => t.RuteId).HasColumnName("RuteId");
            this.Property(t => t.Leveringer).HasColumnName("Leveringer");
            this.Property(t => t.ProduktId).HasColumnName("ProduktId");
        }
    }
}
