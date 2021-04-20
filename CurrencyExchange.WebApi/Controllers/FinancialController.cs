using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Application.Services.Interfaces;
using CurrencyExchange.Application.Utilities.Common;
using CurrencyExchange.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.WebApi.Controllers
{
    public class FinancialController : AppBaseController
    {
        #region Constructor

        private IFinancialPeriodService _financialPeriod;

        public FinancialController(IFinancialPeriodService financialPeriod)
        {
            _financialPeriod = financialPeriod;
        }

        #endregion

        #region Get List

        [HttpGet("list")]
        public async Task<IActionResult> GetInfo()
        {
            var financialList = await _financialPeriod.GetFinancialList();
            if (financialList != null)
            {
                return JsonResponseStatus.Success(financialList);
            }

            return JsonResponseStatus.Error(new { Info = "هنوز لیستی از دوره های مالی وارد نشده است" });
        }

        #endregion

        #region Get List

        [HttpGet("get-by-Id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var financialList = await _financialPeriod.GetById(Convert.ToInt64(id));
            if (financialList != null)
            {
                return JsonResponseStatus.Success(financialList);
            }

            return JsonResponseStatus.Error(new { Info = "هنوز لیستی از دوره های مالی وارد نشده است" });
        }

        #endregion

    }
}
