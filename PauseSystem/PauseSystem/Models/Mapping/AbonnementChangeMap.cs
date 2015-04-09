using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbonnementChangeMap : EntityTypeConfiguration<AbonnementChange>
    {
        public AbonnementChangeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.AbonnementId, t.Antal, t.CreatedDate, t.MadeById, t.ProduktNumber, t.Date });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.AbonnementId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Antal)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MadeById)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ProduktNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("AbonnementChange");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AbonnementId).HasColumnName("AbonnementId");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.MadeById).HasColumnName("MadeById");
            this.Property(t => t.ProduktNumber).HasColumnName("ProduktNumber");
            this.Property(t => t.Date).HasColumnName("Date");
        }
    }
}
