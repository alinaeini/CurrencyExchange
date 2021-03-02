using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Company;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
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
}
