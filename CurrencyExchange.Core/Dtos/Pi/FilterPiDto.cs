﻿using System.Collections.Generic;
using CurrencyExchange.Application.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Pi;

namespace CurrencyExchange.Application.Dtos.Pi
{
    public class FilterPiDto : BasePaging
    {
        #region Properties
       
        public string SearchText { get; set; }
        public string IsRemaindPriceZero { get; set; }
        public List<PiRemaindDto> PiRemaind { get; set; }

        #endregion

        #region Methods

        public FilterPiDto SetPaging(BasePaging paging)
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

        public FilterPiDto SetPies(List<PiRemaindDto> peroformaInvoices)
        {
            this.PiRemaind = peroformaInvoices;
            return this;

        }

        #endregion

    }
}


