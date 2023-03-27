using System.Text.Json;
using AutoMapper;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.User;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest,UpdateUserCommandResponse>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    private IQueueManager _queueManager;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository , IQueueManager queueManager)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _queueManager = queueManager;
    }
     
    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var dbUser =await _userRepository.GetByIdAsync(request.Id);
        if (dbUser is null)
            throw new Exception("user not found");
        
        var dbEmailAddress = dbUser.Email;
        var emailChanged = string.CompareOrdinal(dbEmailAddress, request.Email) != 0;
        
        _mapper.Map(request,dbUser);

        var rows = await _userRepository.UpdateAsync(dbUser);
        
        if (rows > 0 && emailChanged)
        {
            var obj = new UserEmailChangedEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = dbUser.Email,
            };
            var json = JsonSerializer.Serialize(obj);
            
            _queueManager.SendMassageToUserExchange(RabbitMQConstants.UserEmailChangedQueueName,json);
            
            dbUser.EmailConfirmed = false;
            await _userRepository.UpdateAsync(dbUser);
        }

        return new UpdateUserCommandResponse() {Id = dbUser.Id};
    }
}