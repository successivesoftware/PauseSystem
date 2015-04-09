using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ComputerSettingMap : EntityTypeConfiguration<ComputerSetting>
    {
        public ComputerSettingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.LabelprinterId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ComputerName)
                .HasMaxLength(250);

            this.Property(t => t.LabelprinterId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ComputerSettings", "u1000756_FrugtTest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ComputerName).HasColumnName("ComputerName");
            this.Property(t => t.LabelprinterId).HasColumnName("LabelprinterId");
        }
    }
}
