using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Sales;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.RepositoryInterfaces;

namespace CurrencyExchange.Application.Utilities.Design_Patterns.Behavioral_Design_Patterns.Sterategy.Currency
{
    public class ContextCurrencyType
    {
        private ISterategyPatternCurrencyType _currencyType;

        public ContextCurrencyType()
        {

        }

        public ContextCurrencyType(ISterategyPatternCurrencyType currencyType)
        {
            this._currencyType = currencyType;
        }
        public async Task<CurrencySaleDto> SetCurrency(ISterategyPatternCurrencyType currencyType, ICurrencySaleRepository saleRepository, ICurrencySalePiDetailRepository salePiDetailRepository, CurrencySale currencySale)
        {
            _currencyType = currencyType;
            return await _currencyType.GetViewDataFromCurrency(saleRepository, salePiDetailRepository, currencySale);
        }
    }
}