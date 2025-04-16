using EscoteiroLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscoteiroLMS.Infra.Data.EntityConfiguration
{
    public class ResponsibleConfiguration : IEntityTypeConfiguration<Responsible>
    {
        public void Configure(EntityTypeBuilder<Responsible> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(r => r.Name).HasMaxLength(50).IsRequired();
            builder.Property(r => r.Cpf);
            builder.Property(r => r.BirthDate);
            builder.Property(r => r.Phone);
            builder.Property(r => r.EmergencyPhone);
            builder.Property(r => r.Address);
            builder.Property(r => r.Scout);
        }
    }
}
