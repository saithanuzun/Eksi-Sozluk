using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Infrastructure.Persistence.Repositories;

public class EntryRepository : GenericRepository<Entry> , IEntryRepository
{
    public EntryRepository(DbContext dbContext) : base(dbContext)
    {
    }
}