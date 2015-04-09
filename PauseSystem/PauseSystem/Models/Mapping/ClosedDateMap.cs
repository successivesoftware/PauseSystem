using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ClosedDateMap : EntityTypeConfiguration<ClosedDate>
    {
        public ClosedDateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.TimeClosed, t.Year, t.Week, t.DayOfWeek });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Year)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Week)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DayOfWeek)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ClosedDate");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TimeClosed).HasColumnName("TimeClosed");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.DayOfWeek).HasColumnName("DayOfWeek");
            this.Property(t => t.Dato).HasColumnName("Dato");
        }
    }
}
