using ComprasDotnet6.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ComprasDotnet6.Infra.Repositories
{
    public static class PagedBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>(IQueryable<T> query, PagedBaseRequest request)
            where TResponse : PagedBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();
            response.TotalPages = (int)Math.Abs((double)count / request.PageSize);
            response.TotalPages = count;
            if (string.IsNullOrEmpty(request.OrderByProperty))
                response.Data = await query.ToListAsync();
            else
                response.Data = query.OrderByDynamic(request.OrderByProperty)
                                .Skip((request.Page - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .ToList();

            return response;
        }

        private static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> query, string propertyName)
        {
            return query.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));//propertyName é o nome da propriedade e não da coluna no banco
        }
    }
}
