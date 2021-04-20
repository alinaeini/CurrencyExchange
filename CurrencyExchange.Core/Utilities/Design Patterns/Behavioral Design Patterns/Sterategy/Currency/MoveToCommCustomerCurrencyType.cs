using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Sales;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;

namespace CurrencyExchange.Application.Utilities.Design_Patterns.Behavioral_Design_Patterns.Sterategy.Currency
{
    public class MoveToCommCustomerCurrencyType : ISterategyPatternCurrencyType
    {
        private ICommodityCustomerRepository _customerRepository;

        public MoveToCommCustomerCurrencyType(ICommodityCustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CurrencySaleDto> GetViewDataFromCurrency(ICurrencySaleRepository saleRepository,
            ICurrencySalePiDetailRepository salePiDetailRepository, CurrencySale currencySale)
        {
            var filterDto = new CurrencySaleDto();

            var currencySaleItem = await saleRepository.GetCurrencyByIdIncludesBroker(currencySale.Id);
            var sumProfit = await salePiDetailRepository.GetSumProfitLost(currencySale.Id);
            var miscellaneousCustomer = await _customerRepository.GetEntityById(currencySale.CustomerId);
            filterDto = new CurrencySaleDto()
            {
                Id = currencySale.Id,
                BrokerName = currencySaleItem.Broker.Name + " (" + currencySaleItem.Broker.Title + ") ",
                CurrSaleDate = currencySaleItem.SaleDate,
                CustomerName = miscellaneousCustomer.Name,
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