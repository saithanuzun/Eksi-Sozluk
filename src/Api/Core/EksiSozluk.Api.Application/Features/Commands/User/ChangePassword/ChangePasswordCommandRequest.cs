using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.ChangePassword;

public class ChangePasswordCommandRequest : IRequest<ChangePasswordCommandResponse>
{
    public Guid? UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }

}