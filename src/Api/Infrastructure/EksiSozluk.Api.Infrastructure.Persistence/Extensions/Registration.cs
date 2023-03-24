using EksiSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EksiSozluk.Api.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var ConnStr = configuration.GetConnectionString("PostgreSql");
        serviceCollection.AddDbContext<EksiSozlukContext>(conf =>
        {
            conf.UseNpgsql(ConnStr, opt =>
            {
                
            });
        });
        var seedData = new SeedData();
        seedData.SeedAsync(configuration).GetAwaiter().GetResult();
        return serviceCollection;
    }
}