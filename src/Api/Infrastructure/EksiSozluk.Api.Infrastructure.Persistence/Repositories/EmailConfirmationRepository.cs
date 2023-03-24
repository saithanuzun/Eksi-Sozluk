using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Infrastructure.Persistence.Repositories;

public class EmailConfirmationRepository : GenericRepository<EmailConfirmation> , IEmailConfirmationRepository
{
    public EmailConfirmationRepository(DbContext dbContext) : base(dbContext)
    {
    }
}