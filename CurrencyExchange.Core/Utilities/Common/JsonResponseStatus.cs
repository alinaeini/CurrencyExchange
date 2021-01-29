using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Core.Utilities.Common
{
    public static class JsonResponseStatus
    {
        #region Success

        public static JsonResult Success()
        {
            return new JsonResult(new { status = "Success" });
        }

        public static JsonResult Success(object returnData)
        {
            return new JsonResult(new { status = "Success", data = returnData });
        }

        #endregion

        #region NotFound

        public static JsonResult NotFound()
        {
            return new JsonResult(new { status = "Not Found" });
        }

        public static JsonResult NotFound(object returnData)
        {
            return new JsonResult(new { status = "Not Found", data = returnData });
        }

        #endregion

        #region Error

        public static JsonResult Error()
        {
            return new JsonResult(new { status = "Error" });
        }

        public static JsonResult Error(object returnData)
        {
            return new JsonResult(new { status = "Error", data = returnData });
        }

        #endregion

    }

}
