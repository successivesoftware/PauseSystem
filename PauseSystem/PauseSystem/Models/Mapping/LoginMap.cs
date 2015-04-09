using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration; using PauseSystem.Models.Entity;

namespace PauseSystem.Models.Mapping
{
    public class LoginMap : EntityTypeConfiguration<Login>
    {
        public LoginMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Logins");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.LoginDate).HasColumnName("LoginDate");
            this.Property(t => t.LogoutDate).HasColumnName("LogoutDate");
            this.Property(t => t.LoggedOut).HasColumnName("LoggedOut");
        }
    }
}
