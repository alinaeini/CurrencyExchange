using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Sales;
using CurrencyExchange.Core.Dtos.Sales.CurrencySaleExDec;
using CurrencyExchange.Core.Dtos.Sales.CurrencySalePi;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Common;
using CurrencyExchange.WebApi.Controllers.Base;

namespace CurrencyExchange.WebApi.Controllers
{
    public class CurrencyController : AppBaseController
    {
        #region Constructor

        private readonly ICurrencySaleService _saleService;
        private readonly ICurrencySaleDetailExDecService _saleDetailExDecService;
        private readonly ICurrencySaleDetailPiService _saleDetailPiService;


        public CurrencyController(ICurrencySaleService saleService, ICurrencySaleDetailExDecService saleDetailExDecService,
            ICurrencySaleDetailPiService saleDetailPiService)
        {
            _saleService = saleService;
            _saleDetailExDecService = saleDetailExDecService;
            _saleDetailPiService = saleDetailPiService;
        }

        #endregion

        #region Create

        [HttpPost("create")]
        public async Task<IActionResult> CreateSales([FromBody] CreateSaleDto createSaleDto)
        {
            if (ModelState.IsValid)
            {
                var res = await _saleService.Create(createSaleDto);
                switch (res)
                {
                    case SalesResult.CanNotUpdateSoldExDecInDataBase:
                        return JsonResponseStatus.Error(new
                            {Info = "هنوز اظهارنامه به لیست فروش رفته ها وارد نشده است "});

                    case SalesResult.CanNotUpdateSoldPiDetailInDataBase:
                        return JsonResponseStatus.Error(new {Info = "هنوز PI به لیست فروش رفته ها وارد نشده است "});

                    case SalesResult.SumBrokerAccountBalanceIsLowerThanPrice:
                        return JsonResponseStatus.Error(new
                            {Info = " مقدار انتخاب شده برای فروش از مقدار موجودی کارگزار بیشتر است"});

                    case SalesResult.ExDecAccountBalanceIsLowerThanPrice:
                        return JsonResponseStatus.Error(new
                            {Info = "مقدارانتخاب شده برای فروش از مقدار  موجودی اظهارنامه بیشتر است"});
                }
            }

            return JsonResponseStatus.Success();
        }

        #endregion

        #region Filter - ExDec

        #region Get List OF Crrency Sale PiDetail By CurrencySaleId

        [HttpGet("sale-filter-exdec-currSale")]
        public async Task<IActionResult> GetFilterExDecByCurrencyId([FromQuery] FilterCurrSaleExDecDto filterPiDto)
        {
            var exdec = await _saleDetailExDecService.GetListExDecSalesByCurrencyId(filterPiDto);
            return JsonResponseStatus.Success(exdec);
        }

        #endregion

        #region Get List OF Crrency Sale ExDec By ExdecId

        [HttpGet("sale-filter-exdec")]
        public async Task<IActionResult> GetFilterExDec([FromQuery] FilterCurrSaleExDecDto filterPiDto)
        {
            var exDec = await _saleDetailExDecService.GetListExDecSalesByExdecId(filterPiDto);
            return JsonResponseStatus.Success(exDec);
        }

        #endregion

        #endregion

        #region Filter - PiDetail

        #region Get List OF Crrency Sale PiDetail By CurrencySaleId

        [HttpGet("sale-filter-pi-currSale")]
        public async Task<IActionResult> GetFilterPiByCurrencyId([FromQuery] FilterCurrSalePiDto filterPiDto)
        {
            var piDetail = await _saleDetailPiService.GetListPiSalesByCurrencyId(filterPiDto);
            return JsonResponseStatus.Success(piDetail);
        }

        #endregion

        #region Get List OF Crrency Sale PiDetail By PiId

        [HttpGet("sale-filter-pi")]
        public async Task<IActionResult> GetFilterPiByPiDetailId([FromQuery] FilterCurrSalePiDto filterPiDto)
        {
            var piDetail = await _saleDetailPiService.GetListExDecSalesByPiDetailId(filterPiDto);
            return JsonResponseStatus.Success(piDetail);
        }

        #endregion

        #endregion

        #region Filter On CurrencySale

        [HttpGet("sale-filter-currSale")]
        public async Task<IActionResult> GetFilterCurrencySale([FromQuery] FilterCurrSaleDto filterPiDto)
        {
            var piDetail = await _saleService.GetListSales(filterPiDto);
            return JsonResponseStatus.Success(piDetail);
        }

        #endregion
    }
}