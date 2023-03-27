using EksiSozluk.Api.Application.Encryptor;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommandRequest,ChangePasswordCommandResponse>
{
    private IUserRepository _userRepository;
     
    public async Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.UserId.HasValue)
            throw new ArgumentNullException("user id null");

        var dbUser = await _userRepository.GetByIdAsync(request.UserId.Value);

        if (dbUser is null)
            throw new Exception("user not found");

        var encPassword = PasswordEncryptor.Encrypt(request.OldPassword);

        if (encPassword != dbUser.Password)
            throw new Exception("password is wrong");
        
        dbUser.Password = PasswordEncryptor.Encrypt(request.NewPassword);
        await _userRepository.UpdateAsync(dbUser);
        return new ChangePasswordCommandResponse() { PasswordChanged = true };
    }
}