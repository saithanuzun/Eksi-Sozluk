using System.Text.Json;
using AutoMapper;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.User;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
{
    private IMapper _mapper;
    private IUserRepository _userRepository;
    private IQueueManager _queueManager;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository , IQueueManager queueManager)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _queueManager = queueManager;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var existUser = await _userRepository.GetSingleAsync(i => i.Email == request.Email);

        if (existUser is not null)
            throw new Exception("User Already Exist");

        var dbUser = _mapper.Map<Domain.Entities.User>(request);

        var rows = await _userRepository.AddAsync(dbUser);
        if (rows > 0)
        {
            var @event = new UserEmailChangedEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = dbUser.Email,
            };
            var obj = JsonSerializer.Serialize(@event);
            
            _queueManager.SendMassageToExchange(
                obj:obj,
                exchangeName: RabbitMQConstants.UserExchangeName,
                exchangeType: RabbitMQConstants.DefaultExchangeType,
                queueName: RabbitMQConstants.UserEmailChangedQueueName);
        }

        return new CreateUserCommandResponse() {Id = dbUser.Id};
    }
}