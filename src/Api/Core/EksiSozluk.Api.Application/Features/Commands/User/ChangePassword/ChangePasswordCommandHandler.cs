using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommandRequest,ChangePasswordCommandResponse>
{
    public Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}