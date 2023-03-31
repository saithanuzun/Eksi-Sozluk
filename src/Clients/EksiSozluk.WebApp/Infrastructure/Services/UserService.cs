using System.Net.Http.Json;
using System.Text.Json;
using EksiSozluk.WebApp.Infrastructure.Models.DTO;
using EksiSozluk.WebApp.Infrastructure.Models.DVO;
using EksiSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace EksiSozluk.WebApp.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly HttpClient _client;

    public UserService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<UserDetailsDvo> GetUserDetail(Guid? id)
    {
        var userDetail = await _client.GetFromJsonAsync<UserDetailsDvo>($"/api/user/{id}");

        return userDetail;
    }

    public async Task<UserDetailsDvo> GetUserDetail(string userName)
    {
        var userDetail = await _client.GetFromJsonAsync<UserDetailsDvo>($"/api/user/username/{userName}");

        return userDetail;
    }

    public async Task<bool> UpdateUser(UserDetailsDvo user)
    {
        var res = await _client.PostAsJsonAsync($"/api/user/update", user);

        return res.IsSuccessStatusCode;
    }

    public async Task<bool> ChangeUserPassword(string oldPassword, string newPassword)
    {
        var command = new ChangeUserPasswordDto(null, oldPassword, newPassword);
        var httpResponse = await _client.PostAsJsonAsync($"/api/User/ChangePassword", command);

        if (httpResponse != null && !httpResponse.IsSuccessStatusCode)
        {
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var responseStr = await httpResponse.Content.ReadAsStringAsync();
                var validation = JsonSerializer.Deserialize<object>(responseStr, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                throw new Exception(responseStr);
            }

            return false;
        }

        return httpResponse.IsSuccessStatusCode;
    }
}