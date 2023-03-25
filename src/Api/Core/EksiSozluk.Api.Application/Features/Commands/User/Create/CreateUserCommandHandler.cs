using AutoMapper;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository; 
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var existUser = _userRepository.GetSingleAsync(i => i.Email == request.Email);

        if (existUser is not null)
            throw new Exception("User Already Exist");

        var dbUser = _mapper.Map<Domain.Entities.User>(request);

        var rows = await _userRepository.AddAsync(dbUser);
        //email changed rabbitmq
        
            
        
            
        throw new NotImplementedException();
    }
}