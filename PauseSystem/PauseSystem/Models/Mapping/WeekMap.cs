using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; 
using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class WeekMap : EntityTypeConfiguration<Week>
    {
        public WeekMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Week");
            this.Property(t => t.WeekNr).HasColumnName("WeekNr");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Ture).HasColumnName("Ture");
            this.Property(t => t.Ændringer).HasColumnName("Ændringer");
            this.Property(t => t.IkkeTilføjet).HasColumnName("IkkeTilføjet");
            this.Property(t => t.FrugtDK).HasColumnName("FrugtDK");
            this.Property(t => t.Undtagelser).HasColumnName("Undtagelser");
            this.Property(t => t.Ydelser).HasColumnName("Ydelser");
            this.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
