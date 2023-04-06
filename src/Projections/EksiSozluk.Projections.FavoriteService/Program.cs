using EksiSozluk.Projections.FavoriteService;
using EksiSozluk.Projections.FavoriteService.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<FavoriteService>();
    })
    .Build();

await host.RunAsync();