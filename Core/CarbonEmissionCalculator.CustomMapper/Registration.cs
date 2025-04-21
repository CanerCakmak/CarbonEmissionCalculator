using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CarbonEmissionCalculator.CustomMapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<ICustomMapper, AutoMapper.CustomMapper>();
        }
    }
}
