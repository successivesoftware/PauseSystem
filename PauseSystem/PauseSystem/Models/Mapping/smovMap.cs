using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class smovMap : EntityTypeConfiguration<smov>
    {
        public smovMap()
        {
            // Primary Key
            this.HasKey(t => t.TurTurId);

            // Properties
            this.Property(t => t.TurTurId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Fornavn)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("smovs", "u1000756_FrugtTest");
            this.Property(t => t.TurTurId).HasColumnName("TurTurId");
            this.Property(t => t.Fornavn).HasColumnName("Fornavn");
        }
    }
}
