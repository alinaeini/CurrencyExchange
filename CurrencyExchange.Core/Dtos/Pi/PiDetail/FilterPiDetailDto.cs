using System.Collections.Generic;
using CurrencyExchange.Core.Dtos.Paging;

namespace CurrencyExchange.Core.Dtos.Pi.PiDetail
{
    public class FilterPiDetailDto : BasePaging
    {
        #region Properties

        public string SearchText { get; set; }
        public long PiId { get; set; }
        public List<PiDetailDto> PiDetailDtos { get; set; }

        #endregion

        #region Methods

        public FilterPiDetailDto SetPaging(BasePaging paging)
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

        public FilterPiDetailDto SetPiDetails(List<PiDetailDto> piDetailDtos)
        {
            this.PiDetailDtos = piDetailDtos;
            return this;

        }

        #endregion

    }
}