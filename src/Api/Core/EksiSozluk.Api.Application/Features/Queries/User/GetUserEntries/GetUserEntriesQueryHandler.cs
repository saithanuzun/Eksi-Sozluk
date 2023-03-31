using EksiSozluk.Api.Application.Extensions;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Application.Features.Queries.User.GetUserEntries;

public class
    GetUserEntriesQueryHandler : IRequestHandler<GetUserEntriesQueryRequest,
        PagedViewModel<GetUserEntriesQueryResponse>>
{
    private readonly IEntryRepository _entryRepository;

    public GetUserEntriesQueryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task<PagedViewModel<GetUserEntriesQueryResponse>> Handle(GetUserEntriesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();

        if (request.UserId != null && request.UserId.HasValue && request.UserId != Guid.Empty)
            query = query.Where(i => i.CreatedById == request.UserId);
        else if (!string.IsNullOrEmpty(request.Username))
            query = query.Where(i => i.CreatedBy.Username == request.Username);
        else
            throw new Exception("request cannot be null");

        query = query.Include(i => i.EntryFavurites)
            .Include(i => i.CreatedBy);

        var list = query.Select(i => new GetUserEntriesQueryResponse
        {
            Id = i.Id,
            Subject = i.Subject,
            Content = i.Content,
            IsFavorited = false,
            FavoritedCount = i.EntryFavurites.Count,
            CreatedDate = i.CreatedDate,
            CreatedByUserName = i.CreatedBy.Username
        });

        var entries = await list.GetPaged(request.Page, request.PageSize);

        return entries;
    }
}