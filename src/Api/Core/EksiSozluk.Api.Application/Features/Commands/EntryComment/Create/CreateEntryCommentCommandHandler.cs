using AutoMapper;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Commands.EntryComment.Create;

public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentCommandRequest,CreateEntryCommentCommandResponse>
{
    private readonly IEntryCommentRepository _entryCommentRepository;
    private readonly IMapper _mapper;

    public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
    {
        _entryCommentRepository = entryCommentRepository;
        _mapper = mapper;
    }

    public async Task<CreateEntryCommentCommandResponse> Handle(CreateEntryCommentCommandRequest request, CancellationToken cancellationToken)
    {
        var dbEntryComment = _mapper.Map<Domain.Entities.EntryComment>(request);
        await _entryCommentRepository.AddAsync(dbEntryComment);

        return new CreateEntryCommentCommandResponse() { EntryCommentId = dbEntryComment.Id };
    }
}