using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Data.Context;
using CurrencyExchange.Data.Repositories.Generics;
using CurrencyExchange.Domain.EntityModels.Sales;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Data.Repositories
{
    public class CurrencySaleExDecRepository : GenericRepository<CurrencySaleDetailExDec>, ICurrencySaleExDecRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;

        public CurrencySaleExDecRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Sum Exchange Declaration in per  Sales Used 

        public async Task<long> GetSumExCodeUsedById(long exDecId)
        {
            return await _context.CurrencySaleDetailExDecs
                .Where(entity => entity.ExDeclarationId == exDecId)
                .SumAsync(entity => entity.Price);
        }




        #region GetExDecList


        public async Task<List<CurrencySaleDetailExDec>> GetExDecList(long currSaleId)
        {
            return await _context.CurrencySaleDetailExDecs
                .Where(x=>x.CurrencySaleId== currSaleId)
                .ToListAsync();
        }

        #endregion
        #endregion


    }
}