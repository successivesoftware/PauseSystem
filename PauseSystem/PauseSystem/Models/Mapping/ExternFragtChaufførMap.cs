using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ExternFragtChaufførMap : EntityTypeConfiguration<ExternFragtChauffør>
    {
        public ExternFragtChaufførMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.ExternFragtId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ExternFragtId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Navn)
                .HasMaxLength(250);

            this.Property(t => t.Telefon)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ExternFragtChauffør");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ExternFragtId).HasColumnName("ExternFragtId");
            this.Property(t => t.Navn).HasColumnName("Navn");
            this.Property(t => t.Telefon).HasColumnName("Telefon");
        }
    }
}
