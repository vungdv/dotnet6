using airproject.domain.Application.Ports.Inbound;
using airproject.domain.Application.Services;
using airproject.domain.Domain;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAirProjectDomain(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<QueryAirConditionForCityCommand, Location>, AirConditionForCityService>();
            services.AddSingleton<IValidator<QueryAirConditionForCityCommand>, QueryAirConditionForCityCommandValidator>();
            services.AddScoped(typeof(IServiceManager<,>), typeof(ServiceManager<,>));
            services.AddSingleton<IRequestStore, RequestStore>();
            return services;
        }
    }
}
