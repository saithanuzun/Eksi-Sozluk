using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.ConfirmEmail;

public class ConfirmEmailCommandRequest : IRequest<ConfirmEmailCommandResponse>
{
    public Guid ConfirmationId { get; set; }
}