using System.Collections.Generic;
using CurrencyExchange.Application.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Paging;

namespace CurrencyExchange.Application.Dtos.Pi.PiDetail
{
    public class FilterPiDetailCompleteDto : BasePaging
    {
        #region Properties

        public string SearchText { get; set; }
        public string FromDateSale { get; set; }
        public string ToDateSale { get; set; }
        public List<PiDetailCompleteDto> PiDetailDtos { get; set; }

        #endregion

        #region Methods

        public FilterPiDetailCompleteDto SetPaging(BasePaging paging)
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

        public FilterPiDetailCompleteDto SetPiDetails(List<PiDetailCompleteDto> piDetailDtos)
        {
            this.PiDetailDtos = piDetailDtos;
            return this;

        }

        #endregion

    }
}