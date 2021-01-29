using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Broker;
using CurrencyExchange.Core.Dtos.Pi;


namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface IBrokerService :IDisposable
    {
        public Task<BrokerResult> Create(CreateBrokerDto brokerDto);
        Task<FilterBrokerDto> GetBrokersByFiltersList(FilterBrokerDto filterBrokerDto);
        Task<List<BrokerDto>> GetBrokers();
        Task<BrokerDto> GetBrokerById(long id);
        Task<BrokerResult> EditBrokerInfo(BrokerDto brokerDto);
        Task<BrokerResult> DeleteBrokerInfo(long Id);
    }
}