using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class UgeStatistikMap : EntityTypeConfiguration<UgeStatistik>
    {
        public UgeStatistikMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Year, t.Week, t.KundeId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Year)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Week)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.KundeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("UgeStatistik");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
            this.Property(t => t.Omsæt).HasColumnName("Omsæt");
            this.Property(t => t.Db).HasColumnName("Db");
            this.Property(t => t.Dg).HasColumnName("Dg");
        }
    }
}
