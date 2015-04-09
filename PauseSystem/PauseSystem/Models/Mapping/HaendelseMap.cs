using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class HaendelseMap : EntityTypeConfiguration<Haendelse>
    {
        public HaendelseMap()
        {
            // Primary Key
            this.HasKey(t => t.LeveringsId);

            // Properties
            this.Property(t => t.LeveringsId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Hændelse)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.Action)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Haendelse");
            this.Property(t => t.LeveringsId).HasColumnName("LeveringsId");
            this.Property(t => t.Hændelse).HasColumnName("Hændelse");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.MedarbejderId).HasColumnName("MedarbejderId");
        }
    }
}
