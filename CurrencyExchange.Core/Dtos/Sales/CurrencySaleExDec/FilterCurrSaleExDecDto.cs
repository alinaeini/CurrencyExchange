using System.Collections.Generic;
using CurrencyExchange.Application.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Sales.CurrencySaleExDec;

namespace CurrencyExchange.Application.Dtos.Sales.CurrencySaleExDec
{
    public class FilterCurrSaleExDecDto : BasePaging
    {
        #region Properties

        public string SearchText { get; set; }
        public long Id { get; set; }
        public List<CurrencySaleExDecDto> CurrencySaleExDecs { get; set; }


        #endregion

        #region Methods

        public FilterCurrSaleExDecDto SetPaging(BasePaging paging)
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

        public FilterCurrSaleExDecDto SetCurrencySaleExDec(List<CurrencySaleExDecDto> currencySaleExDecs)
        {
            this.CurrencySaleExDecs = currencySaleExDecs;
            return this;

        }

        #endregion

    }
}