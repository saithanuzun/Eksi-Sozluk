using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Infrastructure.Persistence.Context;
using EksiSozluk.Api.Infrastructure.Persistence.RabbitMQ;
using EksiSozluk.Api.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EksiSozluk.Api.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connStr = configuration.GetConnectionString("PostgreSql");

        serviceCollection.AddDbContext<EksiSozlukContext>(conf =>
        {
            conf.UseNpgsql(connStr, opt => { opt.EnableRetryOnFailure(); });
        });
        
        //var seedData = new SeedData();
        //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
        serviceCollection.AddScoped<IEntryRepository, EntryRepository>();
        serviceCollection.AddScoped<IEntryCommentRepository, EntryCommentRepository>();
        
        serviceCollection.AddScoped<IQueueManager, QueueManager>();


        return serviceCollection;
    }
}