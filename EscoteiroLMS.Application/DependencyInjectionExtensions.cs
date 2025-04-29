using EscoteiroLMS.Application.AutoMapper;
using EscoteiroLMS.Application.Contact;
using Microsoft.Extensions.DependencyInjection;

namespace EscoteiroLMS.Application

{
    public static class DependencyInjectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services) 
        {
            services.AddScoped<IContactUseCase, ContactUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
            
        }
    }
}
