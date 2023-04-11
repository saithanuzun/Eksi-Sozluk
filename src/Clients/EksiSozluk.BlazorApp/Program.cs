using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EksiSozluk.BlazorApp;
using EksiSozluk.BlazorApp.Infrastructure.Auth;
using EksiSozluk.BlazorApp.Infrastructure.Services;
using EksiSozluk.BlazorApp.Infrastructure.Services.Interfaces;
using EksiSozluk.WebApp.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient("WebApiClient", client =>
    {
        client.BaseAddress = new Uri("https://localhost:1515");
    })
    .AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped(sp => 
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiClient");
});

builder.Services.AddScoped<AuthTokenHandler>();

builder.Services.AddTransient<IEntryService, EntryService>();
builder.Services.AddTransient<IVoteService, VoteService>();
builder.Services.AddTransient<IFavService, FavService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IIdentityService, IdentityService>();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();