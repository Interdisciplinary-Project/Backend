using EscoteiroLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EscoteiroLMS.Infra.Data.EntityConfiguration
{ 
    
        public class ScoutConfiguration : IEntityTypeConfiguration<Scout>
        {
            public void Configure(EntityTypeBuilder<Scout> builder)
            {
                builder.HasKey(t => t.Id);
                builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
                builder.Property(s => s.Cpf);
                builder.Property(s => s.BirthDate);
                builder.Property(s => s.Phone);
                builder.Property(s => s.EmergencyPhone);
                builder.ComplexProperty(
                 property => property.Address,
                 complexPropertyBuilder => { complexPropertyBuilder.IsRequired();
                 }
                 );
             }
        }
}
