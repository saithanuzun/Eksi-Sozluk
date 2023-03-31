using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Domain.Entities;
using EksiSozluk.Api.Infrastructure.Persistence.Context;

namespace EksiSozluk.Api.Infrastructure.Persistence.Repositories;

public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
{
    public EntryCommentRepository(EksiSozlukContext dbContext) : base(dbContext)
    {
    }
}