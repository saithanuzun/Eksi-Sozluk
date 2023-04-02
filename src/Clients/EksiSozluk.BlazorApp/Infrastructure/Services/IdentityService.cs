using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using EksiSozluk.BlazorApp.Infrastructure.Auth;
using EksiSozluk.BlazorApp.Infrastructure.Extensions;
using EksiSozluk.BlazorApp.Infrastructure.Models.DTO;
using EksiSozluk.BlazorApp.Infrastructure.Models.DVO;
using EksiSozluk.BlazorApp.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace EksiSozluk.BlazorApp.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _client;


    public IdentityService(HttpClient client)
    {
        _client = client;
    }
    private JsonSerializerOptions defaultJsonOpt => new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly HttpClient httpClient;
    private readonly ISyncLocalStorageService syncLocalStorageService;
    private readonly AuthenticationStateProvider authenticationStateProvider;


    public IdentityService(HttpClient httpClient, ISyncLocalStorageService syncLocalStorageService, AuthenticationStateProvider authenticationStateProvider)
    {
        this.httpClient = httpClient;
        this.syncLocalStorageService = syncLocalStorageService;
        this.authenticationStateProvider = authenticationStateProvider;
    }


    public bool IsLoggedIn => !string.IsNullOrEmpty(GetUserToken());

    public string GetUserToken()
    {
        return syncLocalStorageService.GetToken();
    }

    public string GetUserName()
    {
        return syncLocalStorageService.GetToken();
    }

    public Guid GetUserId()
    {
        return syncLocalStorageService.GetUserId();
    }

    public async Task<bool> Login(LoginUserDto command)
    {
        string responseStr;
        var httpResponse = await httpClient.PostAsJsonAsync("/api/User/Login", command);

        if (httpResponse != null && !httpResponse.IsSuccessStatusCode)
        {
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                responseStr = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(responseStr);
            }

            return false;
        }


        responseStr = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<LoginUserDvo>(responseStr);

        if (!string.IsNullOrEmpty(response.Token)) // login success
        {
            syncLocalStorageService.SetToken(response.Token);
            syncLocalStorageService.SetUsername(response.UserName);
            syncLocalStorageService.SetUserId(response.Id);

            ((AuthStateProvider)authenticationStateProvider).NotifyUserLogin(response.UserName, response.Id);

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", response.Token);

            return true;
        }

        return false;
    }

    public void Logout()
    {
        syncLocalStorageService.RemoveItem(LocalStorageExtension.TokenName);
        syncLocalStorageService.RemoveItem(LocalStorageExtension.UserName);
        syncLocalStorageService.RemoveItem(LocalStorageExtension.UserId);

        ((AuthStateProvider)authenticationStateProvider).NotifyUserLogout();
        httpClient.DefaultRequestHeaders.Authorization = null;
    }
}