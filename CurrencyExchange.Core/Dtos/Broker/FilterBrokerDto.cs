using System.Collections.Generic;
using CurrencyExchange.Application.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Paging;

namespace CurrencyExchange.Core.Dtos.Broker
{
    public class FilterBrokerDto : BasePaging
    {
        public string SearchText { get; set; }
        public List<BrokerDto> BrokerDtos { get; set; }

        public FilterBrokerDto SetPaging(BasePaging paging)
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

        public FilterBrokerDto SetBroker(List<BrokerDto> brokers)
        {
            BrokerDtos = brokers;
            return this;
        }
    }
}