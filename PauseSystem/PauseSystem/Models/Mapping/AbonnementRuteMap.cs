using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbonnementRuteMap : EntityTypeConfiguration<AbonnementRute>
    {
        public AbonnementRuteMap()
        {
            // Primary Key
            HasKey(t => t.RuteId);
            Property(t => t.Id).HasColumnName("Uid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).
                IsRequired();
            Property(t => t.RuteId).HasColumnName("RuteId");
            Property(t => t.Ugedag).HasColumnName("DayOfWeek").HasColumnType("int");
            Property(t => t.ChaufførId).HasColumnName("Chauffør");
            Property(t => t.StartAdresseId).HasColumnName("StartAdresse");
            Property(t => t.EndAdresseId).HasColumnName("EndAdresse");
            Property(t => t.Index).HasColumnName("ABIndex");
            Property(t => t.Navn).HasMaxLength(500).HasColumnName("Name");
            Property(t => t.Printes).HasColumnName("Printes");
            Property(t => t.BilId).HasColumnName("Bil");
            Property(t => t.AddToRoute).HasColumnName("AddToRoute");
            Property(t => t.Ophørt).HasColumnName("Ophørt");
        
            HasRequired(t => t.EndAdresse).WithMany().HasForeignKey(t => t.EndAdresseId);
            HasRequired(t => t.StartAdresse).WithMany().HasForeignKey(t => t.StartAdresseId);
            HasRequired(t => t.Chauffør).WithMany().HasForeignKey(t => t.ChaufførId);
            HasMany(t => t.Abonnementer).WithRequired(t => t.AbonnementRute).HasForeignKey(t => t.RuteNr);

            ToTable("AbonnementRute");
        }
    }
}
