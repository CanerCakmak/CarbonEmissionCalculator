using CarbonEmissionCalculator.Application.Interfaces.Repositories;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Persistence.Context;
using CarbonEmissionCalculator.Persistence.Repositories;
using CarbonEmissionCalculator.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarbonEmissionCalculator.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<AppDbContext>(opt =>
            //{
            //    opt.UseInMemoryDatabase("InMemoryDbForTesting"); // "InMemoryDbForTesting" is the name of your in-memory database
            //});

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
