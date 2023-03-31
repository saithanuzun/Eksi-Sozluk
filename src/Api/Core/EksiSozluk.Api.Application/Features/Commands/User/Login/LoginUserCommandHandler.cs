using System.Security.Claims;
using AutoMapper;
using EksiSozluk.Api.Application.Encryptor;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.Jwt;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace EksiSozluk.Api.Application.Features.Commands.User.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var dbUser = await _userRepository.GetSingleAsync(i => i.Email == request.Email);

        if (dbUser is null)
            throw new Exception("user not found");

        var password = PasswordEncryptor.Encrypt(request.Password);

        if (password != dbUser.Password)
            throw new Exception("Password is wrong");

        //if (!dbUser.EmailConfirmed)
        //    throw new Exception("Email Has not confirmed yet");

        var result = _mapper.Map<LoginUserCommandResponse>(dbUser);

        var claims = new Claim[]
        {
            new(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
            new Claim(ClaimTypes.Email, dbUser.Email),
            new Claim(ClaimTypes.Name, dbUser.Username),
            new Claim(ClaimTypes.GivenName, dbUser.FirstName),
            new Claim(ClaimTypes.Surname, dbUser.LastName)
        };

        var secret = _configuration["AuthConfig:Secret"];
        result.Token = TokenGenerator.GenerateToken(claims,secret);

        return result;
    }
}