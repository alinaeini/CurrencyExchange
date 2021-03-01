using System.Collections.Generic;
using CurrencyExchange.Core.Dtos.Paging;

namespace CurrencyExchange.Core.Dtos.ExDecalaration
{
    public class FilterExDecDto : BasePaging
    {
        public string SearchText { get; set; }
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
