using AutoMapper;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.Entry.Create;

public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommandRequest,CreateEntryCommandResponse>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IMapper _mapper;

    public CreateEntryCommandHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        _entryRepository = entryRepository;
        _mapper = mapper;
    }
    public async Task<CreateEntryCommandResponse> Handle(CreateEntryCommandRequest request, CancellationToken cancellationToken)
    {
        var dbEntry = _mapper.Map<Domain.Entities.Entry>(request);
        await _entryRepository.AddAsync(dbEntry);

        return new CreateEntryCommandResponse() { Id = dbEntry.Id };

    }
}