using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class DekorterMap : EntityTypeConfiguration<Dekorter>
    {
        public DekorterMap()
        {
            // Primary Key
            this.HasKey(t => t.LeveringsId);

            // Properties
            this.Property(t => t.LeveringsId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("Dekorter");
            this.Property(t => t.LeveringsId).HasColumnName("LeveringsId");
            this.Property(t => t.MedarbejderId).HasColumnName("MedarbejderId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.Dekort).HasColumnName("Dekort");
            this.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
