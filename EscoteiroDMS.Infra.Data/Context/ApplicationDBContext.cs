using EscoteiroLMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EscoteiroLMS.Infra.Data.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Scout> Scouts { get; set; }
        public DbSet<BranchDto> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);  
        }
    }
}
