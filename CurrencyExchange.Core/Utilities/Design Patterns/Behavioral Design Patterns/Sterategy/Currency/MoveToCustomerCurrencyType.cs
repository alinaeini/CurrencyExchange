using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Sales;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;

namespace CurrencyExchange.Application.Utilities.Design_Patterns.Behavioral_Design_Patterns.Sterategy.Currency
{
    public class MoveToCustomerCurrencyType : ISterategyPatternCurrencyType
    {
        public async Task<CurrencySaleDto> GetViewDataFromCurrency(ICurrencySaleRepository saleRepository, ICurrencySalePiDetailRepository salePiDetailRepository, CurrencySale currencySale)
        {

            //var currencySaleItem = (CurrencyType)_currencySale.CurrencyType == CurrencyType.CarrencySales ? await _saleRepository.GetCurrencyByIdIncludesCustomerAndBroker(_currencySale.Id) : await _saleRepository.GetCurrencyByIdIncludesBroker(_currencySale.Id);
            var currencySaleItem = await saleRepository.GetCurrencyByIdIncludesCustomerAndBroker(currencySale.Id);
            var sumProfit = (CurrencyType)currencySale.CurrencyType == CurrencyType.CarrencySales ? await salePiDetailRepository.GetSumProfitLost(currencySale.Id) :0;
            var filterDto = new CurrencySaleDto()
            {
                Id = currencySale.Id,
                BrokerName = currencySaleItem.Broker.Name + " (" + currencySaleItem.Broker.Title + ") ",
                CurrSaleDate = currencySaleItem.SaleDate,
                CustomerName = currencySaleItem.Customer.Name,
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