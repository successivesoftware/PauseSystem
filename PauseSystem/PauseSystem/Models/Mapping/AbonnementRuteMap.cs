using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbonnementRuteMap : EntityTypeConfiguration<AbonnementRute>
    {
        public AbonnementRuteMap()
        {
            // Primary Key
            this.HasKey(t => t.Uid);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("AbonnementRute");
            this.Property(t => t.RuteId).HasColumnName("RuteId");
            this.Property(t => t.DayOfWeek).HasColumnName("DayOfWeek");
            this.Property(t => t.Chauffør).HasColumnName("Chauffør");
            this.Property(t => t.StartAdresse).HasColumnName("StartAdresse");
            this.Property(t => t.AbIndex).HasColumnName("AbIndex");
            this.Property(t => t.StartTid).HasColumnName("StartTid");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Printes).HasColumnName("Printes");
            this.Property(t => t.Uid).HasColumnName("Uid");
            this.Property(t => t.EndAdresse).HasColumnName("EndAdresse");
            this.Property(t => t.Bil).HasColumnName("Bil");
            this.Property(t => t.AddToRoute).HasColumnName("AddToRoute");
            this.Property(t => t.Ophørt).HasColumnName("Ophørt");
        }
    }
}
