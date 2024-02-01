using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Template.CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddapplicationServieces(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
