using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Data.Context;
using CurrencyExchange.Data.Repositories.Generics;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Data.Repositories
{
    public class PiDetailRepository : GenericRepository<PeroformaInvoiceDetail>, IPiDetailRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        public PiDetailRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region PeroformaInvoice Detail Related Methods

        #region Soled

        public async Task<bool> SoldedPiDetail(long id)
        {
            var piDetail = await _context.PeroformaInvoiceDetails.FirstOrDefaultAsync(x => x.Id == id);
            piDetail.IsSold = true;
            _context.PeroformaInvoiceDetails.Update(piDetail);
            await _context.SaveChangesAsync();
            return true;

        }

        #endregion


        #region SumPayDetails

        public async Task<long> SumPayDetails(long id)
        {
            return await _context.PeroformaInvoiceDetails
                .Where(entity => entity.PeroformaInvoiceId == id)
                .SumAsync(x => x.DepositPrice);
        }



        #endregion

        #region GetSumBrokerAccountBalance

        public async Task<long> GetSumBrokerAccountBalance(long brokerId)
        {
            return await _context.PeroformaInvoiceDetails
                .Where(entity => entity.BrokerId == brokerId )
                .SumAsync(x => x.DepositPrice);
        }

        #endregion


        #region GetAccountBalanceByDetailsByBrokerId

        public async Task<List<PeroformaInvoiceDetail>> GetAccountBalanceByDetailsByBrokerId(long brokerId)
        {
            return await _context.PeroformaInvoiceDetails
                .Include(x=>x.PeroformaInvoice)
                .Where(entity => entity.BrokerId == brokerId && !entity.IsSold)
                .OrderBy(x => x.DepositDate)
                .ToListAsync();
        }

        #endregion

        #endregion

    }
}