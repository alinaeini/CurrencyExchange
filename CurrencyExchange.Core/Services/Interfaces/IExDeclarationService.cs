using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.ExDecalaration;
using CurrencyExchange.Core.Dtos.ExDecalaration;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface IExDeclarationService :IDisposable
    {
       public  Task<ExDeclarationResult> CreateExDec(CreateExDecDto exDeclaration);

        public Task<FilterExDecDto> GetExDecsByFiltersList(FilterExDecDto filterExDecDto);

        public Task<ExDecDto> GetExDecById(long id);
        public Task<List<ExDecRemaindDto>> GetExDecs();
        public Task<ExDeclarationResult> EditExDecInfo(ExDecDto exDecDto);

        public Task<ExDeclarationResult> DeleteExDecInfo(long id);
        public Task<FilterExDecDto> GetExDecsByFilterSoldAndExdecList(FilterExDecDto filterExDecDto);
    }
}