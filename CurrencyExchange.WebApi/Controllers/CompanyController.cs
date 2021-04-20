using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Application.Services.Interfaces;
using CurrencyExchange.Application.Utilities.Common;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Common;
using CurrencyExchange.WebApi.Controllers.Base;

namespace CurrencyExchange.WebApi.Controllers
{
    public class CompanyController : AppBaseController
    {
        #region Constructor

        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        #endregion

        #region Check User Authentication

        
        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            var companyInfo =await  _companyService.GetCompanyInfo();
            if (companyInfo != null)
            {
                return JsonResponseStatus.Success(companyInfo);
            }

            return JsonResponseStatus.Error(new { Info = "هنوز مشخصات شرکت در سیستم درج نشده است" });
        }

        #endregion

    }
}
