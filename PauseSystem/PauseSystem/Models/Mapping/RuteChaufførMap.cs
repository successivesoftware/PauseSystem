using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class RuteChaufførMap : EntityTypeConfiguration<RuteChauffør>
    {
        public RuteChaufførMap()
        {
            // Primary Key
            this.HasKey(t => t.Rute);

            // Properties
            this.Property(t => t.Rute)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("RuteChauffør");
            this.Property(t => t.Rute).HasColumnName("Rute");
            this.Property(t => t.Chauffør).HasColumnName("Chauffør");
        }
    }
}
