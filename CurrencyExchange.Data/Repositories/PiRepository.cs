using System.Linq;
using CurrencyExchange.Data.Context;
using CurrencyExchange.Data.Repositories.Generics;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.RepositoryInterfaces;

namespace CurrencyExchange.Data.Repositories
{
    public class PiRepository : GenericRepository<PeroformaInvoice>, IPiRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        public PiRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion


        #region PeroformaInvoice Related Methods

        public bool IsPiExistByCode(string piCode)
        {
            var isExist = _context.PeroformaInvoices.Any(pi => pi.PiCode == piCode);
            return isExist;
        }

        #endregion

    }
}