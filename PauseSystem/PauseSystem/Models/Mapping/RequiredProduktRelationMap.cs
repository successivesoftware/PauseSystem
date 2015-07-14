using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubusiDbEf.Models.Mappings
{
    public class RequiredProduktRelationMap : EntityTypeConfiguration<RequiredProduktRelation>
    {
        public  RequiredProduktRelationMap() : base()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.FromProduktId).HasColumnName("FromProduktId");
            Property(p => p.ToProduktId).HasColumnName("ToProduktId");
            Property(p => p.Ratio).HasColumnName("Ratio");
            HasRequired(p => p.FromProdukt).WithMany(p=>p.RequiredProduktRelations).HasForeignKey(p => p.FromProduktId);
            HasRequired(p => p.ToProdukt).WithMany(p=>p.ProduktRequiredRelations).HasForeignKey(p => p.ToProduktId);


            ToTable("RequiredProduktRelation");

        }
    }
}
