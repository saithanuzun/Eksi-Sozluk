using AutoMapper;
using AutoMapper.QueryableExtensions;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetEntries;

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQueryRequest, List<GetEntriesQueryResponse>>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IMapper _mapper;

    public GetEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        _entryRepository = entryRepository;
        _mapper = mapper;
    }

    public async Task<List<GetEntriesQueryResponse>> Handle(GetEntriesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = _entryRepository.AsQueryable();
        if (request.TodaysEntries)
            query = query
                .Where(i => i.CreatedDate >= DateTime.Now.Date)
                .Where(i => i.CreatedDate <= DateTime.Now.AddDays(1).Date);

        var queryable = query.Include(i => i.EntryComments)
            .OrderByDescending(i => i.EntryComments.Count)
            .Take(request.Count);

        return await queryable.ProjectTo<GetEntriesQueryResponse>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}