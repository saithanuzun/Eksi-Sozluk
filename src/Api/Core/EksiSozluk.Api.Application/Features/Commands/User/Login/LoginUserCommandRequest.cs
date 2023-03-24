using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.Login;

public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}