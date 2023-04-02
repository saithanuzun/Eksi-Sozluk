using EksiSozluk.BlazorApp.Infrastructure.Models.DTO;

namespace EksiSozluk.BlazorApp.Infrastructure.Services.Interfaces;

public interface IIdentityService
{
    bool IsLoggedIn { get; }
    string GetUserToken();
    string GetUserName();
    Guid GetUserId();
    Task<bool> Login(LoginUserDto command);
    void Logout();
}