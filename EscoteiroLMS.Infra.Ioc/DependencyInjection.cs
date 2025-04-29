using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Application.Services;
using EscoteiroLMS.Domain.Interfaces;
using EscoteiroLMS.Infra.Data.Context;
using EscoteiroLMS.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EscoteiroLMS.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>();
            services.AddScoped<IResponsibleRepository, ResponsibleRepository>();
            services.AddScoped<IResponsibleService, ResponsibleService>();
        }
    }
}
