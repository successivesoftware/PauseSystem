using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class TureMap : EntityTypeConfiguration<Ture>
    {
        public TureMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Ture");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.DayOfWeek).HasColumnName("DayOfWeek");
            this.Property(t => t.TurId).HasColumnName("TurId");
            this.Property(t => t.Edit).HasColumnName("Edit");
            this.Property(t => t.Leveringer).HasColumnName("Leveringer");
            this.Property(t => t.PackedBy).HasColumnName("PackedBy");
            this.Property(t => t.CheckedBy).HasColumnName("CheckedBy");
            this.Property(t => t.StartTid).HasColumnName("StartTid");
            this.Property(t => t.Chauffør).HasColumnName("Chauffør");
            this.Property(t => t.StartAdress).HasColumnName("StartAdress");
            this.Property(t => t.EndAdress).HasColumnName("EndAdress");
            this.Property(t => t.DoPrint).HasColumnName("DoPrint");
            this.Property(t => t.EditBy).HasColumnName("EditBy");
            this.Property(t => t.LastEdit).HasColumnName("LastEdit");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Car).HasColumnName("Car");
            this.Property(t => t.Km).HasColumnName("Km");
            this.Property(t => t.Packed).HasColumnName("Packed");
            this.Property(t => t.Dato).HasColumnName("Dato");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.AntalLeveringer).HasColumnName("AntalLeveringer");
            this.Property(t => t.AntalProdukter).HasColumnName("AntalProdukter");
            this.Property(t => t.AddToRoute).HasColumnName("AddToRoute");
            this.Property(t => t.ExternFragtChauffør).HasColumnName("ExternFragtChauffør");
        }
    }
}
