using AutoMapper;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetMainPageEntries;

public class GetMainPageEntriesQueryHandler : IRequestHandler<GetMainPageEntriesQueryRequest,PagedViewModel<GetMainPageEntriesQueryResponse>>
{
    private IEntryRepository _entryRepository;
    private IMapper _iMapper;

    public GetMainPageEntriesQueryHandler(IEntryRepository entryRepository, IMapper iMapper)
    {
        _entryRepository = entryRepository;
        _iMapper = iMapper;
    }

    public Task<PagedViewModel<GetMainPageEntriesQueryResponse>> Handle(GetMainPageEntriesQueryRequest request, CancellationToken cancellationToken)
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
            
            
        });
            
        
        throw new NotImplementedException();
    }
}