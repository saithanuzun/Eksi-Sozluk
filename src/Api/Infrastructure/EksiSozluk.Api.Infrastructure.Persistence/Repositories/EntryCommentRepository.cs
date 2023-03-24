using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Infrastructure.Persistence.Repositories;

public class EntryCommentRepository : GenericRepository<EntryComment> , IEntryCommentRepository
{
    public EntryCommentRepository(DbContext dbContext) : base(dbContext)
    {
    }
}