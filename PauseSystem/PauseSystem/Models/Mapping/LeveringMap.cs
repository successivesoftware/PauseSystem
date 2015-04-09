using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class LeveringMap : EntityTypeConfiguration<Levering>
    {
        public LeveringMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.WeekNr, t.Year, t.KundeNr, t.Produkt, t.Adresse, t.Pris, t.Zindex, t.Antal, t.IsOrdre, t.RuteId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.WeekNr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Year)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.KundeNr)
                .IsRequired();

            this.Property(t => t.Produkt)
                .IsRequired();

            this.Property(t => t.Adresse)
                .IsRequired();

            this.Property(t => t.Pris)
                .IsRequired();

            this.Property(t => t.Zindex)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Antal)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RuteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Levering");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.WeekNr).HasColumnName("WeekNr");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.KundeNr).HasColumnName("KundeNr");
            this.Property(t => t.Produkt).HasColumnName("Produkt");
            this.Property(t => t.Adresse).HasColumnName("Adresse");
            this.Property(t => t.Pris).HasColumnName("Pris");
            this.Property(t => t.Zindex).HasColumnName("Zindex");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.IsOrdre).HasColumnName("IsOrdre");
            this.Property(t => t.SenesteLeveringsTid).HasColumnName("SenesteLeveringsTid");
            this.Property(t => t.RuteId).HasColumnName("RuteId");
            this.Property(t => t.Leveret).HasColumnName("Leveret");
            this.Property(t => t.Dekort).HasColumnName("Dekort");
            this.Property(t => t.PrintLabel).HasColumnName("PrintLabel");
            this.Property(t => t.PrintPakkeListe).HasColumnName("PrintPakkeListe");
            this.Property(t => t.AbonnementId).HasColumnName("AbonnementId");
        }
    }
}
