using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class MedarbejderOpgaverMap : EntityTypeConfiguration<MedarbejderOpgaver>
    {
        public MedarbejderOpgaverMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.EmployeeId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Navn)
                .HasMaxLength(50);

            this.Property(t => t.EmployeeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MedarbejderOpgaver");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Navn).HasColumnName("Navn");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
            this.Property(t => t.IsDone).HasColumnName("IsDone");
            this.Property(t => t.TaskId).HasColumnName("TaskId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
