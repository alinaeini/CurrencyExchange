using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CurrencyExchange.Application.Dtos.ExDecalaration;
using CurrencyExchange.Application.Utilities.Common;
using CurrencyExchange.Core.Dtos.ExDecalaration;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Common;
using CurrencyExchange.WebApi.Controllers.Base;

namespace CurrencyExchange.WebApi.Controllers
{
    public class ExdeclarationController : AppBaseController
    {
        #region Constructor

        private IExDeclarationService exDeclarationService;

        public ExdeclarationController(IExDeclarationService exDeclarationService)
        {
            this.exDeclarationService = exDeclarationService;
        }

        #endregion

        #region Create

        [HttpPost("create")]
        public async Task<IActionResult> CreateExdec([FromBody] CreateExDecDto exDeclarationDto)
        {
            if (ModelState.IsValid)
            {
                var res = await exDeclarationService.CreateExDec(exDeclarationDto);
                switch (res)
                {
                    case ExDeclarationResult.ExDecIsExist:
                        return JsonResponseStatus.Error(new {Info = "شماره اظهارنامه وارد شده قبلا در سیستم ثبت شده"});
                }
            }

            return JsonResponseStatus.Success();
        }

        #endregion

        #region Filter ExDecs

        #region GetExDecsIsNotSold

        [HttpGet("filter-exdec-sold")]
        public async Task<IActionResult> GetExDecsIsNotSold([FromQuery] FilterExDecDto filterExDecDto)
        {
            var exDecs = await exDeclarationService.GetExDecsByFiltersList(filterExDecDto);
            return JsonResponseStatus.Success(exDecs);
        }

        #endregion

        #region GetExDecAll

        [HttpGet("filter-exdec-all")]
        public async Task<IActionResult> GetExDecAll([FromQuery] FilterExDecDto filterExDecDto)
        {
            var exDecs = await exDeclarationService.GetExDecsByFilterSoldAndExdecList(filterExDecDto);
            return JsonResponseStatus.Success(exDecs);
        }

        #endregion

        #endregion

        #region Edit ExDec

        [HttpPost("edit-exdec")]
        public async Task<IActionResult> EditExDec([FromBody] ExDecDto exDecDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = await exDeclarationService.EditExDecInfo(exDecDto);
                switch (result)
                {
                    case ExDeclarationResult.ExDecCanNotUpdate:
                        return JsonResponseStatus.Error(new {info = "اظهارنامه ویرایش نشد "});
                }
            }

            return JsonResponseStatus.Success();
        }


        [HttpGet("edit-exdec-get/{id}")]
        public async Task<IActionResult> GetEditExDecById(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                long exDecId = long.Parse(id);
                var exDec = await exDeclarationService.GetExDecById(exDecId);
                return JsonResponseStatus.Success(exDec);
            }

            return JsonResponseStatus.Error(new {info = "اظهارنامه ویرایش نشد "});
        }

        #endregion

        #region Get ExDeclaration List

        [HttpGet("exDecs")]
        public async Task<IActionResult> GetExDecList()
        {
            if (User.Identity.IsAuthenticated)
            {
                var exDecList = await exDeclarationService.GetExDecs();
                return JsonResponseStatus.Success(exDecList);
            }

            return JsonResponseStatus.Error(new {info = "هیچ اظهارنامه ای دریافت نشد "});
        }

        #endregion

        #region Delete

        [HttpGet("delete-exdec/{id}")]
        public async Task<IActionResult> DeleteExDecById(string id)
        {
            var exDec = ExDeclarationResult.Success;
            if (User.Identity.IsAuthenticated)
            {
                long exdecId = long.Parse(id);
                exDec = await exDeclarationService.DeleteExDecInfo(exdecId);
                switch (exDec)
                {
                    case ExDeclarationResult.ExDecCanNotDelete:
                        return JsonResponseStatus.Error(new {info = "اظهارنامه حذف نشد "});
                }
            }

            return JsonResponseStatus.Success(exDec);
        }

        #endregion
    }
}