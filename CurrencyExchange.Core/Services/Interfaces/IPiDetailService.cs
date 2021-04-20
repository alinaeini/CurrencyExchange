using System;
using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.Pi.PiDetail;
using CurrencyExchange.Core.Dtos.Pi.PiDetail;

namespace CurrencyExchange.Application.Services.Interfaces
{
    public interface IPiDetailService : IDisposable
    {
        public Task<PiDetailResult> Create(CreatePiDetailDto createPiDetailDto);
        public Task<FilterPiDetailDto> GetPiesByFiltersList(FilterPiDetailDto filterPiDetailDto);
        public Task<FilterPiDetailCompleteDto> GetPiPayList(FilterPiDetailCompleteDto filterPiDetailDto);
        Task<PiDetailDto> GetPiDetailById(long id);
        Task<PiDetailResult> EditPiInfo(PiDetailDto piDetailDto);
        Task<PiDetailResult> DeletePiDetailInfo(long id);
        Task<long> GetTotalAamountReceivedFromTheCustomer(long id);

    }
}