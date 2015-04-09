using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ChangeMap : EntityTypeConfiguration<Change>
    {
        public ChangeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.KundeId, t.OldAdresseId, t.OldDate, t.OldProduktId, t.OldRute, t.NewRute, t.OldAntal, t.Status, t.CreatedDate });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.KundeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OldAdresseId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OldProduktId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OldRute)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NewRute)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OldAntal)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Status)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Changes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
            this.Property(t => t.OldAdresseId).HasColumnName("OldAdresseId");
            this.Property(t => t.NewAdresseId).HasColumnName("NewAdresseId");
            this.Property(t => t.OldDate).HasColumnName("OldDate");
            this.Property(t => t.NewDate).HasColumnName("NewDate");
            this.Property(t => t.OldProduktId).HasColumnName("OldProduktId");
            this.Property(t => t.NewProduktId).HasColumnName("NewProduktId");
            this.Property(t => t.OldRute).HasColumnName("OldRute");
            this.Property(t => t.NewRute).HasColumnName("NewRute");
            this.Property(t => t.OldAntal).HasColumnName("OldAntal");
            this.Property(t => t.NewAntal).HasColumnName("NewAntal");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.MedarbejderId).HasColumnName("MedarbejderId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
