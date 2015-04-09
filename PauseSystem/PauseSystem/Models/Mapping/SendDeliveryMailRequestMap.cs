using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class SendDeliveryMailRequestMap : EntityTypeConfiguration<SendDeliveryMailRequest>
    {
        public SendDeliveryMailRequestMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RequestId, t.CustomerNr, t.Sent });

            // Properties
            this.Property(t => t.RequestId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CustomerNr)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SendDeliveryMailRequest", "u1000756_FrugtTest");
            this.Property(t => t.RequestId).HasColumnName("RequestId");
            this.Property(t => t.CustomerNr).HasColumnName("CustomerNr");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Sent).HasColumnName("Sent");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.SentDate).HasColumnName("SentDate");
        }
    }
}
