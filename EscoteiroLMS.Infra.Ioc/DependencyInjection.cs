using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Application.Services;
using EscoteiroLMS.Domain.Interfaces;
using EscoteiroLMS.Infra.Data.Context;
using EscoteiroLMS.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EscoteiroLMS.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer("Data Source=grupoescoteiro.database.windows.net;Initial Catalog=gets;Persist Security Info=True;User ID=gets;Password=grupo123@;Encrypt=True"));

            services.AddScoped<IResponsibleRepository, ResponsibleRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IResponsibleService, ResponsibleService>();
        }
    }
}
