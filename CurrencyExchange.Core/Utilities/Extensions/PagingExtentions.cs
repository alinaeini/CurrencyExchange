using System.Linq;
using CurrencyExchange.Application.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Paging;

namespace CurrencyExchange.Core.Utilities.Extensions
{
    public static class PagingExtentions
    {
        public static IQueryable<TEntiy> Paging<TEntiy>(this IQueryable<TEntiy> queryable, BasePaging pager)
        {
            return queryable.Skip(pager.SkipEntity).Take(pager.TakeEntity);
        }
    }
}
