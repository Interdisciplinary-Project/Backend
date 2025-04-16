using EscoteiroLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EscoteiroLMS.Infra.Data.EntityConfiguration
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Description);
        }
    }
}
