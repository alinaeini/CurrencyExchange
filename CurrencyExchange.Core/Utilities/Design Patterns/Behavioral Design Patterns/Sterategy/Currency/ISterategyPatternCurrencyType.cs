using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Sales;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;

namespace CurrencyExchange.Application.Utilities.Design_Patterns.Behavioral_Design_Patterns.Sterategy.Currency
{
    public interface ISterategyPatternCurrencyType
    {
        public Task<CurrencySaleDto> GetViewDataFromCurrency(ICurrencySaleRepository saleRepository, ICurrencySalePiDetailRepository salePiDetailRepository, CurrencySale currencySale);
    }
}