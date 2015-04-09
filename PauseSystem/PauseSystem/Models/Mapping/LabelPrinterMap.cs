using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class LabelPrinterMap : EntityTypeConfiguration<LabelPrinter>
    {
        public LabelPrinterMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Ip)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("LabelPrinters", "u1000756_FrugtTest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Ip).HasColumnName("Ip");
            this.Property(t => t.Port).HasColumnName("Port");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
