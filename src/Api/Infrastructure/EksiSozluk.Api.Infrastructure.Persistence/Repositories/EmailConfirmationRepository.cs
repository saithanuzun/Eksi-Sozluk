using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Domain.Entities;
using EksiSozluk.Api.Infrastructure.Persistence.Context;

namespace EksiSozluk.Api.Infrastructure.Persistence.Repositories;

public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
{
    public EmailConfirmationRepository(EksiSozlukContext dbContext) : base(dbContext)
    {
    }
}