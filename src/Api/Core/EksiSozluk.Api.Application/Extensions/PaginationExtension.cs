using EksiSozluk.Api.Application.Pagination;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Api.Application.Extensions;

public static class PaginationExtension
{
    public static async Task<PagedViewModel<T>> GetPaged<T>(this IQueryable<T> query, int currentPage, int pageSize)
        where T : class
    {
        var count = await query.CountAsync();
        var paging = new Page(currentPage, pageSize, count);

        var data = await query.Skip(paging.Skip).Take(paging.PageSize).AsNoTracking().ToListAsync();
        var result = new PagedViewModel<T>(data, paging);
        return result;
    }
}