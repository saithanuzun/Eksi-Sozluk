using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.Update;

public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Username { get; set; }
}