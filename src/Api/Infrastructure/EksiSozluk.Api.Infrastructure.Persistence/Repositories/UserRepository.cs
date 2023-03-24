using EksiSozluk.Api.Application.Interfaces.Repositories;
using EksiSozluk.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>,IUserRepository
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }
}