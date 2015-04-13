using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class ProduktMap : EntityTypeConfiguration<Produkt>
    {
        public ProduktMap()
        {
            // Primary Key
            this.HasKey(t => t.ProduktNr);

            this.Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

            // Properties
            this.Property(t => t.Navn)
                .HasMaxLength(250);

            this.Property(t => t.Beskrivelse)
                .HasMaxLength(250);

            this.Property(t => t.Externt)
                .HasMaxLength(50);

            this.Property(t => t.ManufactureNumber)
                .HasMaxLength(250);

            this.Property(t => t.LabelText)
                .HasMaxLength(100);

            this.Property(t => t.Url)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Produkt");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktNr").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
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
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.FølgeProdukt).HasColumnName("FølgeProdukt");
            this.Property(t => t.ManufactureNumber).HasColumnName("ManufactureNumber");
            this.Property(t => t.LabelText).HasColumnName("LabelText");
            this.Property(t => t.SkalIkkeFaktureres).HasColumnName("SkalIkkeFaktureres");
            this.Property(t => t.LeveringMåIkkeSlettes).HasColumnName("LeveringMåIkkeSlettes");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Prisliste).HasColumnName("Prisliste");
            this.Property(t => t.ProducentId).HasColumnName("ProducentId");
        }
    }
}
