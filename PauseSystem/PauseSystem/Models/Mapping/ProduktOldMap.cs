using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ProduktOldMap : EntityTypeConfiguration<ProduktOld>
    {
        public ProduktOldMap()
        {
            // Primary Key
            this.HasKey(t => t.ProduktNr);

            // Properties
            this.Property(t => t.ProduktNr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Navn)
                .HasMaxLength(250);

            this.Property(t => t.Beskrivelse)
                .HasMaxLength(250);

            this.Property(t => t.Externt)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProduktOld");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktNr");
            this.Property(t => t.Navn).HasColumnName("Navn");
            this.Property(t => t.Beskrivelse).HasColumnName("Beskrivelse");
            this.Property(t => t.stk).HasColumnName("stk");
            this.Property(t => t.KostPris).HasColumnName("KostPris");
            this.Property(t => t.SalgsPris).HasColumnName("SalgsPris");
            this.Property(t => t.GrossistPris).HasColumnName("GrossistPris");
            this.Property(t => t.ProduktGruppeId).HasColumnName("ProduktGruppeId");
            this.Property(t => t.Leverandør).HasColumnName("Leverandør");
            this.Property(t => t.Volume).HasColumnName("Volume");
            this.Property(t => t.Provision).HasColumnName("Provision");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Externt).HasColumnName("Externt");
            this.Property(t => t.ProduktUnderGruppeId).HasColumnName("ProduktUnderGruppeId");
        }
    }
}
