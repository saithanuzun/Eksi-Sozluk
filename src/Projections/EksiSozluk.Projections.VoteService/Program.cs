using EksiSozluk.Projections.VoteService;
using EksiSozluk.Projections.VoteService.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<VoteService>();
    })
    .Build();

await host.RunAsync();