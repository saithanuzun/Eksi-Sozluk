using System.Text.Json;
using AutoMapper;
using EksiSozluk.Api.Application.Encryptor;
using EksiSozluk.Api.Application.Interfaces.RabbitMq;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.RabbitMQ;
using EksiSozluk.Api.Application.RabbitMQ.Events.User;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.User.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueueManager _queueManager;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IQueueManager queueManager)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _queueManager = queueManager;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var existUser = await _userRepository.GetSingleAsync(i => i.Email == request.Email);

        if (existUser is not null)
            throw new Exception("User Already Exist");

        request.Password = PasswordEncryptor.Encrypt(request.Password);
        var dbUser = _mapper.Map<Domain.Entities.User>(request);

        var rows = await _userRepository.AddAsync(dbUser);
        if (rows > 0)
        {
            var obj = new UserEmailChangedEvent
            {
                OldEmailAddress = "null",
                NewEmailAddress = dbUser.Email
            };
            var json = JsonSerializer.Serialize(obj);

            _queueManager.SendMassageToUserExchange(RabbitMQConstants.UserEmailChangedQueueName, json);
        }

        return new CreateUserCommandResponse { Id = dbUser.Id };
    }
}