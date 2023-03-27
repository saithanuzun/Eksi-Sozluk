using System.Reflection;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EksiSozluk.Api.Application.Extensions;

public static class Registration
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection serviceCollection)
    {
        var asm = Assembly.GetExecutingAssembly();

        //serviceCollection.AddMediatR(asm);
        serviceCollection.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        serviceCollection.AddAutoMapper(asm);
        serviceCollection.AddValidatorsFromAssembly(asm);
        

        return serviceCollection;
    }
}