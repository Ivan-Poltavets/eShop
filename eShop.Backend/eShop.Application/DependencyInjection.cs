using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() })
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                
            return services;
        }
    }
}
