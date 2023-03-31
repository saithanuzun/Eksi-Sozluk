using EksiSozluk.Api.Application.Extensions;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Application.Pagination;
using EksiSozluk.Api.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Application.Features.Queries.EntryComment.GetEntryComments;

public class GetEntryCommentsQueryHandler : IRequestHandler<GetEntryCommentsQueryRequest,
    PagedViewModel<GetEntryCommentsQueryResponse>>
{
    private readonly IEntryCommentRepository _entryCommentRepository;


    public GetEntryCommentsQueryHandler(IEntryCommentRepository entryCommentRepository)
    {
        _entryCommentRepository = entryCommentRepository;
    }

    public async Task<PagedViewModel<GetEntryCommentsQueryResponse>> Handle(GetEntryCommentsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var query = _entryCommentRepository.AsQueryable();
        query = query
            .Include(i => i.EntryCommentFavorites)
            .Include(i => i.User)
            .Include(i => i.EntryCommentVotes)
            .Where(i => i.EntryId == request.EntryId);

        var list = query.Select(i => new GetEntryCommentsQueryResponse
        {
            Id = i.Id,
            Content = i.Content,
            FavoritedCount = i.EntryCommentFavorites.Count,
            CreatedDate = i.CreatedDate,
            CreatedByUsername = i.User.Username,
            IsFavorited = request.UserId.HasValue && i.EntryCommentFavorites
                .Any(j => j.CreatedById == request.UserId),
            VoteType =
                request.UserId.HasValue && i.EntryCommentVotes.Any(j => j.CreatedById == request.UserId)
                    ? i.EntryCommentVotes.FirstOrDefault(k => k.CreatedById == request.UserId).VoteType
                    : VoteType.None
        });
        var entries = await list.GetPaged(request.Page, request.PageSize);

        return entries;
    }
}