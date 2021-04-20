using System.Linq;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
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