using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class TurLeveringMap : EntityTypeConfiguration<TurLevering>
    {
        public TurLeveringMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TurLevering");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.KundeId).HasColumnName("KundeId");
            this.Property(t => t.TurId).HasColumnName("TurId");
            this.Property(t => t.AdresseId).HasColumnName("AdresseId");
            this.Property(t => t.Zindex).HasColumnName("Zindex");
            this.Property(t => t.LeveringsTid).HasColumnName("LeveringsTid");
            this.Property(t => t.PrintPakkeListe).HasColumnName("PrintPakkeListe");
            this.Property(t => t.SkipReasonId).HasColumnName("SkipReasonId");
            this.Property(t => t.AbonnementId).HasColumnName("AbonnementId");
        }
    }
}
