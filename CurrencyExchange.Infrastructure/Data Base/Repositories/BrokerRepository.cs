using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Broker;
using CurrencyExchange.Domain.RepositoryInterfaces;
using CurrencyExchange.Infrastructure.Data.Data_Base.Repositories.Generics;
using CurrencyExchange.Infrastructure.Data_Base.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Infrastructure.Data.Data_Base.Repositories
{
    public class BrokerRepository : GenericRepository<Broker>, IBrokerRepository
    {
        #region Constructor

        private readonly CurrencyExchangeDbContext _context;
        public BrokerRepository(CurrencyExchangeDbContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Broker Related Methods 

        public async Task<Broker> GetByName(string name)
            => await _context.Brokers
                .Where(broker => broker.Name == name.Trim().ToLowerInvariant()).SingleOrDefaultAsync();

        public async Task<Broker> GetByTitle(string title)
            => await _context.Brokers
                .Where(broker => broker.Title == title.Trim().ToLowerInvariant()).SingleOrDefaultAsync();

        public bool IsBrokerExistByName(string name)
            => _context.Brokers.Any(broker => broker.Name == name.Trim().ToLowerInvariant());
            

        public bool IsBrokerExistByTitle(string title)
            => _context.Brokers.Any(broker => broker.Name == title.Trim().ToLowerInvariant());

        public async Task<bool> UpdateBrokerAmount(long brokerId, long price, bool isAdd)
        {
            Broker broker =await GetEntityById(brokerId);
            broker.AmountBalanceBroker =
                isAdd ? broker.AmountBalanceBroker + price : broker.AmountBalanceBroker - price;
            UpdateEntity(broker);
            //await SaveChanges();
            return true;

        }

        #endregion
    }
}