using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommandRequest,ConfirmEmailCommandResponse>
{
    private IUserRepository _userRepository;
    private IEmailConfirmationRepository _confirmationRepository;

    public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfirmationRepository confirmationRepository)
    {
        _userRepository = userRepository;
        _confirmationRepository = confirmationRepository;
    }

    public async Task<ConfirmEmailCommandResponse> Handle(ConfirmEmailCommandRequest request, CancellationToken cancellationToken)
    {
        var confirmation = await _confirmationRepository.GetByIdAsync(request.ConfirmationId);

        if (confirmation is null)
            throw new Exception("confirmation not found");

        var dbUser = await _userRepository.GetSingleAsync(i => i.Email == confirmation.NewEmailAddress);
        if(dbUser is null)
            throw new Exception("User not found with this email!");

        if (dbUser.EmailConfirmed)
            throw new Exception("Email address is already confirmed!");

        dbUser.EmailConfirmed = true;
        await _userRepository.UpdateAsync(dbUser);
        
        return new ConfirmEmailCommandResponse() { IsEmailConfirmed = true };
    }
}