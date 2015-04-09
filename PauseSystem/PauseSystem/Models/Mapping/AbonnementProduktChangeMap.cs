using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbonnementProduktChangeMap : EntityTypeConfiguration<AbonnementProduktChange>
    {
        public AbonnementProduktChangeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.AbonnementProduktId, t.Antal, t.CreatedDate, t.MadeById, t.Date });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.AbonnementProduktId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Antal)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MadeById)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AbonnementProduktChange");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AbonnementProduktId).HasColumnName("AbonnementProduktId");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.MadeById).HasColumnName("MadeById");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.ProduktNumber).HasColumnName("ProduktNumber");
        }
    }
}
