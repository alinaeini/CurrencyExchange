using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Pi;
using CurrencyExchange.Core.Dtos.Pi.PiDetail;
using CurrencyExchange.Core.Dtos.Sales;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Common;
using CurrencyExchange.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.WebApi.Controllers
{
    //[Authorize]
    public class PiController : AppBaseController
    {
        #region Constructor

        private readonly IPiService _piService;
        private readonly IPiDetailService _piDetailService;

        public PiController(IPiService piService, IPiDetailService piDetailService)
        {
            _piService = piService;
            _piDetailService = piDetailService;
        }

        #endregion

        #region Peroforma Invoice Controllers

        #region Create


        [HttpPost("create")]
        public async Task<IActionResult> CreatePi([FromBody] CreatePiDto createPiDto)
        {
            if (ModelState.IsValid)
            {
                var res = await _piService.Create(createPiDto);
                switch (res)
                {

                    case PiResult.ProformaInvoiceIsExist:
                        return JsonResponseStatus.Error(new { Info = "شماره PI مورد نظر , قبلا در سیستم ثبت شده" });

                }
            }
            return JsonResponseStatus.Success();
        }

        #endregion

        #region Filter Pi

        #region Filter Pi Is Not Sold

        [HttpGet("filter-pi")]
        public async Task<IActionResult> GetPi([FromQuery] FilterPiDto filterPiDto)
        {
            var pi = await _piService.GetPiesByFiltersList(filterPiDto);
            return JsonResponseStatus.Success(pi);
        }

        #endregion

        #region GetPiAll

        [HttpGet("filter-pi-all")]
        public async Task<IActionResult> GetPiAll([FromQuery] FilterPiDto filterPiDto)
        {
            var pi = await _piService.GetPiesByFiltersIsSold(filterPiDto);
            return JsonResponseStatus.Success(pi);
        }

        #endregion

        #endregion

        #region Edit Pi

        [HttpPost("edit-pi")]
        public async Task<IActionResult> EditPi([FromBody] PiDto piDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = await _piService.EditPiInfo(piDto);
                switch (result)
                {
                    case PiResult.CanNotUpdate:
                        return JsonResponseStatus.Error(new { info = "PI ویرایش نشد " });

                }

            }
            return JsonResponseStatus.Success();

        }


        [HttpGet("edit-pi-get/{id}")]
        public async Task<IActionResult> EditPi(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                long piId = long.Parse(id);
                var pi = await _piService.GetPiById(piId);
                return JsonResponseStatus.Success(pi);
            }

            return JsonResponseStatus.Error(new { info = "PI ویرایش نشد " });
        }
        #endregion

        #region Delete

        [HttpGet("delete-pi/{id}")]
        public async Task<IActionResult> DeletePiById(string id)
        {
            var pi = PiResult.Success;
            if (User.Identity.IsAuthenticated)
            {
                long piId = long.Parse(id);
                pi = await _piService.DeletePiInfo(piId);
                switch (pi)
                {
                    case PiResult.CanNotDelete:
                        return JsonResponseStatus.Error(new { info = "PI حذف نشد " });

                }
            }

            return JsonResponseStatus.Success(pi);
        }

        #endregion

        #endregion

        #region Peroforma Invoice Detail Controllers

        #region Create Detail

        [HttpPost("create-pi-detail")]
        public async Task<IActionResult> CreatePiDetail([FromBody] CreatePiDetailDto createPiDetailDto)
        {
            if (ModelState.IsValid)
            {
                var res = await _piDetailService.Create(createPiDetailDto);
                switch (res)
                {

                    case PiDetailResult.ProformaInvoiceDetailIsExist:
                        return JsonResponseStatus.Error(new { Info = "شماره PI مورد نظر , قبلا در سیستم ثبت شده" });

                }
            }
            return JsonResponseStatus.Success();
        }

        #endregion

        #region Filter Pi Detail

        [HttpGet("filter-pi-detail")]
        public async Task<IActionResult> GetPiDetail([FromQuery] FilterPiDetailDto filterPiDetailDto)
        {
            var piDetail = await _piDetailService.GetPiesByFiltersList(filterPiDetailDto);
            return JsonResponseStatus.Success(piDetail);
        }



        #endregion

        #region Edit Pi Detail

        [HttpPost("edit-pi-detail")]
        public async Task<IActionResult> EditPiDetail([FromBody] PiDetailDto piDetailDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = await _piDetailService.EditPiInfo(piDetailDto);
                switch (result)
                {
                    case PiDetailResult.CanNotUpdate:
                        return JsonResponseStatus.Error(new { info = "PI ویرایش نشد " });

                }

            }
            return JsonResponseStatus.Success();

        }


        [HttpGet("edit-pi-detail-get/{id}")]
        public async Task<IActionResult> EditPiDetail(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                long piId = long.Parse(id);
                var piDetailDto = await _piDetailService.GetPiDetailById(piId);
                return JsonResponseStatus.Success(piDetailDto);
            }

            return JsonResponseStatus.Error(new { info = "PI ویرایش نشد " });
        }
        #endregion

        #region Delete Detail

        [HttpGet("delete-pi-detail/{id}")]
        public async Task<IActionResult> DeletePiDetailById(string id)
        {
            var piDetailResult = PiDetailResult.Success;
            if (User.Identity.IsAuthenticated)
            {
                long piId = long.Parse(id);
                piDetailResult = await _piDetailService.DeletePiDetailInfo(piId);
                switch (piDetailResult)
                {
                    case PiDetailResult.CanNotDelete:
                        return JsonResponseStatus.Error(new { info = "PI حذف نشد " });

                }
            }

            return JsonResponseStatus.Success(piDetailResult);
        }

        #endregion

        #endregion

    }
}
