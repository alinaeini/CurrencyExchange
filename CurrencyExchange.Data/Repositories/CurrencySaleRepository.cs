using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Css.Dom;
using CurrencyExchange.Data.Context;
using CurrencyExchange.Data.Repositories.Generics;
using CurrencyExchange.Domain.EntityModels.Sales;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Data.Repositories
{
    public class CurrencySaleRepository : GenericRepository<CurrencySale>, ICurrencySaleRepository
    {
        #region Constructor
        private readonly CurrencyExchangeDbContext _context;
        public CurrencySaleRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region CurrencySale Related Methods


        public async Task<CurrencySale> GetByIdIncludes(long currSaleId)
        {
            return await _context.CurrencySales
                .Include(x => x.Customer)
                .Include(x => x.Broker)
                .SingleOrDefaultAsync(x => x.Id == currSaleId);
        }


        #endregion



    }
}