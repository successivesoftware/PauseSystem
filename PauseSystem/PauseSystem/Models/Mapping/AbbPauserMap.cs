using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbbPauserMap : EntityTypeConfiguration<AbbPauser>
    {
        public AbbPauserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AbbPauser");
            this.Property(t => t.AbonnementId).HasColumnName("AbonnementId");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Start).HasColumnName("Start");
            this.Property(t => t.Slut).HasColumnName("Slut");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
        }
    }
}
