namespace EksiSozluk.WebApp.Infrastructure.Models.DTO;

public class ChangeUserPasswordDto
{
    public Guid? UserId { get; set; }

    public string OldPassword { get; set; }

    public string NewPassword { get; set; }

    public ChangeUserPasswordDto(Guid? userId, string oldPassword, string newPassword)
    {
        UserId = userId;
        OldPassword = oldPassword;
        NewPassword = newPassword;
    }
}