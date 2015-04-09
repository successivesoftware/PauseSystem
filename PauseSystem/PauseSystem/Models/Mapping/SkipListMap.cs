using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class SkipListMap : EntityTypeConfiguration<SkipList>
    {
        public SkipListMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SkipReason)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("SkipList", "u1000756_FrugtTest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SkipReason).HasColumnName("SkipReason");
        }
    }
}
