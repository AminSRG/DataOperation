using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Common;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(current => current.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<IRsaService, RsaService>();

            return services;
        }
    }
}
