using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class AbonnementerMap : EntityTypeConfiguration<Abonnementer>
    {
        public AbonnementerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Abonnementer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Ugedag).HasColumnName("Ugedag");
            this.Property(t => t.RuteNr).HasColumnName("RuteNr");
            this.Property(t => t.RuteIndex).HasColumnName("RuteIndex");
            this.Property(t => t.LeveringsAdresseId).HasColumnName("LeveringsAdresseId");
            this.Property(t => t.DeliveryTime).HasColumnName("DeliveryTime");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
            this.Property(t => t.KundeNr).HasColumnName("KundeNr");
            this.Property(t => t.StartDato).HasColumnName("StartDato");
            this.Property(t => t.SlutDato).HasColumnName("SlutDato");
            this.Property(t => t.Antal).HasColumnName("Antal");
            this.Property(t => t.StartPause).HasColumnName("StartPause");
            this.Property(t => t.EndPause).HasColumnName("EndPause");
            this.Property(t => t.Ophør).HasColumnName("Ophør");
            this.Property(t => t.ProduktNr).HasColumnName("ProduktNr");
            this.Property(t => t.Interval).HasColumnName("Interval");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.PrintPakkeList).HasColumnName("PrintPakkeList");
            this.Property(t => t.PrintPakkeDato).HasColumnName("PrintPakkeDato");

       //     this.HasRequired(t => t.AbonnementRute).WithMany().HasForeignKey(x => x.AbonnementRute);
            this.HasMany(t => t.AbonnementProdukts).WithOptional().HasForeignKey(x => x.AbonnementId);
            this.HasMany(t => t.AbonnementChanges).WithOptional().HasForeignKey(x => x.AbonnementId);

        }
    }
}
