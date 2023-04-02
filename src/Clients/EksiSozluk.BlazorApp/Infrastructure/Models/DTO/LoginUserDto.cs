namespace EksiSozluk.BlazorApp.Infrastructure.Models.DTO;

public class LoginUserDto
{
    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public LoginUserDto(string emailAddress, string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }

    public LoginUserDto()
    {

    }
}