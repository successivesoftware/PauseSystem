using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class PostNrKundeMap : EntityTypeConfiguration<PostNrKunde>
    {
        public PostNrKundeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.PostNrIntervalId, t.KundeId, t.Ugedag });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.PostNrIntervalId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.KundeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Ugedag)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("PostNrKunde");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PostNrIntervalId).HasColumnName("PostNrIntervalId");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
            this.Property(t => t.Ugedag).HasColumnName("Ugedag");
        }
    }
}
