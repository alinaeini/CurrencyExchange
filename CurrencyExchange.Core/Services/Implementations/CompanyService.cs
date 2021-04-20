using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Html;
using CurrencyExchange.Application.Dtos.Company;
using CurrencyExchange.Application.Services.Interfaces;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Application.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        #region Constructor

        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        #endregion

        #region Methods

        public async Task<CompanyDto> GetCompanyInfo()
        {
            CompanyDto result = null;
            var company = await _companyRepository.GetEntities().FirstOrDefaultAsync();
            if (company != null )
            {
                result = new CompanyDto()
                {
                    CompanyName = company.CompanyName,
                    Address = company.Address,
                    Tel = company.Tel,
                    WebSite = company.WebSite
                };
            }

            return result;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _companyRepository?.Dispose();
        }

        #endregion
    }

    
    public class FinancialPeriodService : IFinancialPeriodService
    {
        #region Constructor

        private IFinancialPeriodRepository _financialPeriodRepository;

        public FinancialPeriodService(IFinancialPeriodRepository financialPeriodRepository)
        {
            _financialPeriodRepository = financialPeriodRepository;
        }

        #endregion

        #region Methods

        public async Task<List<FinancialPeriodDto>> GetFinancialList()
        {
            var result = new List<FinancialPeriodDto>();
            var list =await _financialPeriodRepository.GetEntities().ToListAsync();
            foreach (var item in list)
            {
                result.Add(new FinancialPeriodDto
                {
                    FinancialPeriodId = item.Id,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    PriodName = item.PriodName
                });
            }

            return result;
        }

        public async Task<FinancialPeriodDto> GetById(long id)
        {
            var item = await _financialPeriodRepository.GetEntityById(id);

            return new FinancialPeriodDto
            {
                FinancialPeriodId = item.Id,
                FromDate = item.FromDate,
                ToDate = item.ToDate,
                PriodName = item.PriodName
            };
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
           _financialPeriodRepository?.Dispose();
        }

        #endregion




    }
}
