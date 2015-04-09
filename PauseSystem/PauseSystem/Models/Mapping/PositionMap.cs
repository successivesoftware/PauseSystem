using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class PositionMap : EntityTypeConfiguration<Position>
    {
        public PositionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Positions");
            this.Property(t => t.RouteId).HasColumnName("RouteId");
            this.Property(t => t.Dato).HasColumnName("Dato");
            this.Property(t => t.X).HasColumnName("X");
            this.Property(t => t.y).HasColumnName("y");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
