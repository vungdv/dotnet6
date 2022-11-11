using airproject.domain.Application.Ports.Outbound;
using airproject.providers.openair;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddOpenAir(this IServiceCollection services)
        {
            services.AddTransient<IAirConditionRepository, OpenAirProvider>();
            return services;
        }
    }
}
