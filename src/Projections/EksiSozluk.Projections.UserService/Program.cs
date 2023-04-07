using EksiSozluk.Projections.UserService;
using EksiSozluk.Projections.UserService.Service;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<UserService>();
    })
    .Build();

await host.RunAsync();