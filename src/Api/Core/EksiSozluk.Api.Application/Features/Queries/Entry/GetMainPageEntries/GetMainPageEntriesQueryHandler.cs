using AutoMapper;
using EksiSozluk.Api.Application.Extensions;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.Pagination;
using EksiSozluk.Api.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetMainPageEntries;

public class GetMainPageEntriesQueryHandler : IRequestHandler<GetMainPageEntriesQueryRequest,PagedViewModel<GetMainPageEntriesQueryResponse>>
{
    private IEntryRepository _entryRepository;
    public GetMainPageEntriesQueryHandler(IEntryRepository entryRepository, IMapper iMapper)
    {
        _entryRepository = entryRepository;
    }

    public  async Task<PagedViewModel<GetMainPageEntriesQueryResponse>> Handle(GetMainPageEntriesQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();
        query = query.Include(i => i.EntryFavurites)
            .Include(i => i.CreatedBy)
            .Include(i => i.EntryVotes);

        var list = query.Select(i => new GetMainPageEntriesQueryResponse()
        {
            Id = i.Id,
            Subject = i.Subject,
            Content = i.Content,
            FavoritedCount = i.EntryFavurites.Count,
            CreatedDate = i.CreatedDate,
            CreatedByUserName = i.CreatedBy.Username,
            IsFavorited = request.UserId.HasValue && i.EntryFavurites
                .Any(j=>j.CreatedById==request.UserId),
            VoteType = 
                request.UserId.HasValue && i.EntryVotes.Any(j=>j.CreatedById==request.UserId)
                ? i.EntryVotes.FirstOrDefault(k=>k.CreatedById==request.UserId).VoteType
                : VoteType.None,
        });

        var entries = await list.GetPaged(request.Page, request.PageSize);

        return entries;
    }
}