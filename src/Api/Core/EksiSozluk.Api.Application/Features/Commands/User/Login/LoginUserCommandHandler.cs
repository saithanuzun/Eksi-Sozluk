using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EksiSozluk.Api.Application.Encryptor;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.Jwt;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace EksiSozluk.Api.Application.Features.Commands.User.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration _configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var dbUser = await _userRepository.GetSingleAsync(i => i.Email == request.Email);

        if (dbUser is null)
            throw new Exception("user not found");

        var password = PasswordEncryptor.Encrypt(request.Password);

        if (password != dbUser.Password)
            throw new Exception("Password is wrong");

        if (!dbUser.EmailConfirmed)
            throw new Exception("Email Has not confirmed yet");

        var result = _mapper.Map<LoginUserCommandResponse>(dbUser);
        
        var claims = new Claim[] 
        {
            new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
            new Claim(ClaimTypes.Email, dbUser.Email),
            new Claim(ClaimTypes.Name, dbUser.Username),
            new Claim(ClaimTypes.GivenName, dbUser.FirstName),
            new Claim(ClaimTypes.Surname, dbUser.LastName)
        };

        result.Token = TokenGenerator.GenerateToken(claims,_configuration);
        
        return result;
    }
   
}