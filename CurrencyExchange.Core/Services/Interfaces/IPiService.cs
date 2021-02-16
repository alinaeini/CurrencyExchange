using System;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Pi;
using CurrencyExchange.Core.Dtos.Pi.PiDetail;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface IPiService :IDisposable
    {
        public Task<PiResult> Create(CreatePiDto createPiDto);
        public Task<FilterPiDto> GetPiesByFiltersList(FilterPiDto filterPiDto);
        //public Task<FilterGenericDto<PiRemaindDto>> GetPiesByFiltersList(FilterGenericDto<PiRemaindDto> filterPiDto);
        public Task<FilterPiDto> GetPiesByFiltersIsSold(FilterPiDto filterPiDto);
        public Task<PiDto> GetPiById(long id);
        public Task<PiResult> EditPiInfo(PiDto piDto);
        public Task<PiResult> DeletePiInfo(long id);
        
    }
}
