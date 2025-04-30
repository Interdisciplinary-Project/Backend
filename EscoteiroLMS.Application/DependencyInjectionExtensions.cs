using EscoteiroLMS.Application.AutoMapper;
using EscoteiroLMS.Application.Contact;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EscoteiroLMS.Application
{
    public static class DependencyInjectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddServices(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IContactUseCase, ContactUseCase>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBranchService, BranchService>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }
    }
}
