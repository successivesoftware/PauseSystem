using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class PostNrIntervalMap : EntityTypeConfiguration<PostNrInterval>
    {
        public PostNrIntervalMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Fra, t.Til, t.Mandag, t.Tirsdag, t.Onsdag, t.Torsdag, t.Fredag });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Fra)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Til)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("PostNrInterval");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Fra).HasColumnName("Fra");
            this.Property(t => t.Til).HasColumnName("Til");
            this.Property(t => t.Mandag).HasColumnName("Mandag");
            this.Property(t => t.Tirsdag).HasColumnName("Tirsdag");
            this.Property(t => t.Onsdag).HasColumnName("Onsdag");
            this.Property(t => t.Torsdag).HasColumnName("Torsdag");
            this.Property(t => t.Fredag).HasColumnName("Fredag");
        }
    }
}
