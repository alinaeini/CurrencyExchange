using System.Collections.Generic;
using CurrencyExchange.Application.Dtos.Paging;

namespace CurrencyExchange.Application.Dtos.ExDecalaration
{
    public class FilterExDecDto : BasePaging
    {
        public string SearchText { get; set; }
        public string FromDateSale { get; set; }
        public string ToDateSale { get; set; }
        public string IsRemaindPriceZero { get; set; }
        public List<ExDecRemaindDto> ExDecRemaind { get; set; }

        public FilterExDecDto SetPaging(BasePaging paging)
        {
            PageId = paging.PageId;
            PageCount = paging.PageCount;
            ActivePage = paging.ActivePage;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            TakeEntity = paging.TakeEntity;
            SkipEntity = paging.SkipEntity;
            return this;
        }

        public FilterExDecDto SetExDec(List<ExDecRemaindDto> exDec)
        {
            this.ExDecRemaind = exDec;
            return this;
        }
    }


}
