using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class MedarbejdereMap : EntityTypeConfiguration<Medarbejdere>
    {
        public MedarbejdereMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Fornavn)
                .HasMaxLength(50);

            this.Property(t => t.EfterNavn)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(50);

            this.Property(t => t.PrivatMobil)
                .HasMaxLength(50);

            this.Property(t => t.MsMobil)
                .HasMaxLength(50);

            this.Property(t => t.SugarUser)
                .HasMaxLength(50);

            this.Property(t => t.SugarPassword)
                .HasMaxLength(50);

            this.Property(t => t.PausePassword)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Medarbejdere");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Fornavn).HasColumnName("Fornavn");
            this.Property(t => t.EfterNavn).HasColumnName("EfterNavn");
            this.Property(t => t.Aktiv).HasColumnName("Aktiv");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Rolle).HasColumnName("Rolle");
            this.Property(t => t.PrivatMobil).HasColumnName("PrivatMobil");
            this.Property(t => t.MsMobil).HasColumnName("MsMobil");
            this.Property(t => t.Timeløn).HasColumnName("Timeløn");
            this.Property(t => t.SugarUser).HasColumnName("SugarUser");
            this.Property(t => t.SugarPassword).HasColumnName("SugarPassword");
            this.Property(t => t.OrdreKilde).HasColumnName("OrdreKilde");
            this.Property(t => t.PausePassword).HasColumnName("PausePassword");
            this.Property(t => t.Extern).HasColumnName("Extern");
        }
    }
}
