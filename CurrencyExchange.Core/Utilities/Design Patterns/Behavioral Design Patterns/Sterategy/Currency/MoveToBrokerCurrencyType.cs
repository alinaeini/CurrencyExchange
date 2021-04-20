using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Sales;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;

namespace CurrencyExchange.Application.Utilities.Design_Patterns.Behavioral_Design_Patterns.Sterategy.Currency
{
    public class MoveToBrokerCurrencyType : ISterategyPatternCurrencyType
    {
        private IBrokerRepository _brokerRepository;

        public MoveToBrokerCurrencyType(IBrokerRepository brokerRepository)
        {
            _brokerRepository = brokerRepository;
        }
        public async Task<CurrencySaleDto> GetViewDataFromCurrency(ICurrencySaleRepository saleRepository, ICurrencySalePiDetailRepository salePiDetailRepository, CurrencySale currencySale)
        {
            var currencySaleItem = await saleRepository.GetCurrencyByIdIncludesBroker(currencySale.Id);
            var sumProfit = 0 ;// await salePiDetailRepository.GetSumProfitLost(currencySale.Id);
            var broker = await _brokerRepository.GetEntityById(currencySale.CustomerId);
            var filterDto = new CurrencySaleDto
            {
                Id = currencySale.Id,
                BrokerName = currencySaleItem.Broker.Name + " (" + currencySaleItem.Broker.Title + ") ",
                CurrSaleDate = currencySaleItem.SaleDate,
                CustomerName = broker.Name,
                Price = currencySale.SalePrice,
                ProfitLossAmount = sumProfit,
                SalePricePerUnit = currencySale.SalePricePerUnit,
                TransferPrice = currencySale.TransferPrice,
                TransferType = (CurrencyTransferType)currencySale.TransferType,
                CurrencyType = (CurrencyType)currencySale.CurrencyType
            };
            return filterDto;
        }
    }
}