using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Broker;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Common;
using CurrencyExchange.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.WebApi.Controllers
{
    public class BrokerController : AppBaseController
    {
        #region Constructor

        private readonly IBrokerService _brokerService;

        public BrokerController(IBrokerService brokerService)
        {
            this._brokerService = brokerService;
        }
        #endregion

        #region Create

        [HttpPost("create")]
        public async Task<IActionResult> CreateBroker([FromBody] CreateBrokerDto broker)
        {
            if (ModelState.IsValid)
            {
                var res = await _brokerService.Create(broker);
                switch (res)
                {

                    case BrokerResult.BrokerIsExist:
                        return JsonResponseStatus.Error(new { Info = "کارگزار مورد نظر , قبلا در سیستم ثبت شده" });

                }
            }
            return JsonResponseStatus.Success();
        }

        #endregion

        #region Filter Broker

        [HttpGet("filter-broker")]
        public async Task<IActionResult> GetBroker([FromQuery] FilterBrokerDto filterBrokerDto)
        {
            var Broker = await _brokerService.GetBrokersByFiltersList(filterBrokerDto);
            return JsonResponseStatus.Success(Broker);
        }
        


        #endregion

        #region Edit Broker

        [HttpPost("edit-broker")]
        public async Task<IActionResult> EditBroker([FromBody] BrokerDto BrokerDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = await _brokerService.EditBrokerInfo(BrokerDto);
                switch (result)
                {
                    case BrokerResult.CanNotUpdate:
                        return JsonResponseStatus.Error(new { info = "کارگزار ویرایش نشد " });

                }

            }
            return JsonResponseStatus.Success();

        }


        [HttpGet("edit-broker-get/{id}")]
        public async Task<IActionResult> GetEditBrokerById(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                long ID = long.Parse(id);
                var Broker = await _brokerService.GetBrokerById(ID);
                return JsonResponseStatus.Success(Broker);
            }

            return JsonResponseStatus.Error(new { info = "کارگزار ویرایش نشد " });
        }
        #endregion

        #region GetBrokerList

        [HttpGet("brokers")]
        public async Task<IActionResult> GetBrokerList()
        {
            if (User.Identity.IsAuthenticated)
            {
                var brokerList = await _brokerService.GetBrokers();
                return JsonResponseStatus.Success(brokerList);
            }

            return JsonResponseStatus.Error(new { info = "هیچ کارگزاری دریافت نشد " });
        }

        #endregion

        #region Delete

        [HttpGet("delete-broker/{id}")]
        public async Task<IActionResult> DeleteBrokerById(string id)
        {
            var Broker = BrokerResult.Success;
            if (User.Identity.IsAuthenticated)
            {
                long ID = long.Parse(id);
                Broker = await _brokerService.DeleteBrokerInfo(ID);
                switch (Broker)
                {
                    case BrokerResult.CanNotDelete:
                        return JsonResponseStatus.Error(new { info = "کارگزار حذف نشد " });

                }
            }

            return JsonResponseStatus.Success(Broker);
        }

        #endregion
       
    }
}