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
        Task<PiDto> GetPiById(long id);
        Task<PiResult> EditPiInfo(PiDto piDto);
        Task<PiResult> DeletePiInfo(long id);

    }
}
