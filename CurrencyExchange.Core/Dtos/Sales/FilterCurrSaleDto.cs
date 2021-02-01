using System.Collections.Generic;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Sales.CurrencySalePi;

namespace CurrencyExchange.Core.Dtos.Sales
{
    public class FilterCurrSaleDto : BasePaging
    {
        #region Properties

        public string SearchText { get; set; }
        public List<CurrencySaleDto> CurrencySale { get; set; }

        #endregion

        #region Methods

        public FilterCurrSaleDto SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.PageCount = paging.PageCount;
            this.ActivePage = paging.ActivePage;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            return this;

        }

        public FilterCurrSaleDto SetCurrencySale(List<CurrencySaleDto> currencySale)
        {
            this.CurrencySale = currencySale;
            return this;

        }

        #endregion

    }
}