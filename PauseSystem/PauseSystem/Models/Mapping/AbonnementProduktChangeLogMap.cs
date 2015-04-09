using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbonnementProduktChangeLogMap : EntityTypeConfiguration<AbonnementProduktChangeLog>
    {
        public AbonnementProduktChangeLogMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.KundeId, t.CreatedBy, t.PauseStart, t.PauseEnd, t.CreatedDate });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.KundeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Produkt)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("AbonnementProduktChangeLog", "u1000756_FrugtTest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.PauseStart).HasColumnName("PauseStart");
            this.Property(t => t.PauseEnd).HasColumnName("PauseEnd");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.Produkt).HasColumnName("Produkt");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.AbonnementProduktId).HasColumnName("AbonnementProduktId");
            this.Property(t => t.SentDate).HasColumnName("SentDate");
            this.Property(t => t.PauseId).HasColumnName("PauseId");
        }
    }
}
