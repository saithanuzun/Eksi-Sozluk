using AutoMapper;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest,UpdateUserCommandResponse>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository; 
    }
     
    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var dbUser =await _userRepository.GetByIdAsync(request.Id);
        if (dbUser is null)
            throw new Exception("user not found");

        _mapper.Map(request,dbUser);

        var rows = await _userRepository.UpdateAsync(dbUser);
        //check if email changed
           
        
         
        
        throw new NotImplementedException();
    }
}