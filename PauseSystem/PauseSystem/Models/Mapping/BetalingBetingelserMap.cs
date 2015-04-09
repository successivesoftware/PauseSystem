using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class BetalingBetingelserMap : EntityTypeConfiguration<BetalingBetingelser>
    {
        public BetalingBetingelserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Text)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("BetalingBetingelser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StdRegValue).HasColumnName("StdRegValue");
            this.Property(t => t.Text).HasColumnName("Text");
        }
    }
}
