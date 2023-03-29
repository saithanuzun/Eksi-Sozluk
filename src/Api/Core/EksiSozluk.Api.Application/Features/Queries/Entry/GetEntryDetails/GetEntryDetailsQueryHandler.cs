using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetEntryDetails;

public class GetEntryDetailsQueryHandler : IRequestHandler<GetEntryDetailsQueryRequest,GetEntryDetailsQueryResponse>
{
    private IEntryRepository _entryRepository;

    public GetEntryDetailsQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<GetEntryDetailsQueryResponse> Handle(GetEntryDetailsQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();
        query = query.Include(i => i.EntryFavurites)
            .Include(i => i.CreatedBy)
            .Include(i => i.EntryVotes)
            .Where(i => i.Id == request.UserId);

        var list = query.Select(i => new GetEntryDetailsQueryResponse()
        {
            Id = i.Id,
            Subject = i.Subject,
            Content = i.Content,
            IsFavorited = request.UserId.HasValue && i.EntryFavurites.Any(j => j.CreatedById == request.UserId),
            FavoritedCount = i.EntryFavurites.Count,
            CreatedDate = i.CreatedDate,
            CreatedByUserName = i.CreatedBy.Username,
            VoteType =
                request.UserId.HasValue && i.EntryVotes.Any(j => j.CreatedById == request.UserId)
                    ? i.EntryVotes.FirstOrDefault(j => j.CreatedById == request.UserId).VoteType
                    : VoteType.None
        });

        return list.FirstOrDefault();
    }
}