namespace EksiSozluk.BlazorApp.Infrastructure.Models.DVO;

public class LoginUserDvo
{
    public LoginUserDvo(Guid id, string firstName, string lastName, string userName, string token)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Token = token;
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }

    public string Token { get; set; }
}