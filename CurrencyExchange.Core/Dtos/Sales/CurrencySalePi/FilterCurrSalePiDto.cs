using System.Collections.Generic;
using CurrencyExchange.Application.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Paging;

namespace CurrencyExchange.Core.Dtos.Sales.CurrencySalePi
{
    public class FilterCurrSalePiDto : BasePaging
    {
        #region Properties

        public string SearchText { get; set; }
        public long Id { get; set; }
        public List<CurrencySaleDetailPiDto> CurrencySaleDetailPi { get; set; }

        #endregion

        #region Methods

        public FilterCurrSalePiDto SetPaging(BasePaging paging)
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

        public FilterCurrSalePiDto SetCurrencySaleExDec(List<CurrencySaleDetailPiDto> currencySaleDetailPi)
        {
            this.CurrencySaleDetailPi = currencySaleDetailPi;
            return this;

        }

        #endregion

    }
}