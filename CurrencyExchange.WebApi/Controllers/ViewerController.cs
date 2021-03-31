using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Common;
using CurrencyExchange.Core.Dtos.Sales;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Angular;
using Stimulsoft.Report.Web;

namespace CurrencyExchange.WebApi.Controllers
{
    [Controller]
    public class ViewerController : Controller
    {
        public readonly object _data;
        public readonly string _reportName;
        public readonly StiRequestParams _viewer;

        public ViewerController()
        {
        }

        //public ViewerController(object data, string reportName, StiRequestParams viewer)
        //{
        //    _data = data;
        //    _reportName = reportName;
        //    _viewer = viewer;
        //}
        //public ViewerController(object data, string reportName, Controller controller)
        //{
        //    _data = data;
        //    _reportName = reportName;
        //    _controller = controller;
        //}
        //public ViewerController(object data, string reportName)
        //{
        //    this._data = data;
        //    this._reportName = reportName;
        //}
        [HttpPost]
        public IActionResult InitViewer()

        {
            var requestParams = StiAngularViewer.GetRequestParams(this);
            var options = new StiAngularViewerOptions();

            options.Actions.ViewerEvent = "ViewerEvent";
            options.Localization = "Localization/fa.xml";

            options.Appearance.ScrollbarsMode = true;
            options.Appearance.FullScreenMode = true;
            //options.Toolbar.DisplayMode = StiToolbarDisplayMode.Separated;
            options.Toolbar.ShowParametersButton = false;
            //options.Toolbar.FontFamily = "IRANSansDN";
            //options.Toolbar.FontColor = Color.Brown;
            options.Theme = StiViewerTheme.Office2013WhiteBlue;

            return StiAngularViewer.ViewerDataResult(requestParams, options);
        }

        [HttpPost]
        public IActionResult ViewerEvent()

        {
            var requestParams = StiAngularViewer.GetRequestParams(this);
            var reportName = GetReportName();
            var data = GetData();

            var dt = JsonConvert.DeserializeObject(data.ToString());
            //var json = StiJsonConnector.Get();
            //var dataSet = json.GetDataSet(new StiJsonOptions(data));÷


            if (requestParams.Action == StiAction.GetReport)

            {
                var report = StiReport.CreateNewReport();
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                var path = StiAngularHelper.MapPath(this, "wwwroot/Reports/Currency/" + reportName);
                string Date_shamsi = pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" +
                                     pc.GetDayOfMonth(DateTime.Now);
                report.Load(path);
                //report.RegData("dt", data.ToString());
                report.RegData("dt", dt);
                report.Dictionary.Variables["shamsiDate"].Value = Date_shamsi;
                return StiAngularViewer.GetReportResult(this, report);
            }

            return StiAngularViewer.ProcessRequestResult(this);
        }


        private string GetReportName()
        {
            var httpContext = new Stimulsoft.System.Web.HttpContext(this.HttpContext);
            var properties = httpContext.Request.Params["properties"]?.ToString();
            if (properties != null)
            {
                var data = Convert.FromBase64String(properties);
                var json = Encoding.UTF8.GetString(data);
                JContainer container = JsonConvert.DeserializeObject<JContainer>(json);
                foreach (JToken token in container.Children())
                {
                    if (((JProperty) token).Name == "reportName")
                    {
                        return ((JProperty) token).Value.Value<string>();
                    }
                }
            }

            return null;
        }

        private object GetData()
        {
            var httpContext = new Stimulsoft.System.Web.HttpContext(this.HttpContext);
            var properties = httpContext.Request.Params["properties"]?.ToString();
            if (properties != null)
            {
                var data = Convert.FromBase64String(properties);
                var json = Encoding.UTF8.GetString(data);
                JContainer container = JsonConvert.DeserializeObject<JContainer>(json);
                foreach (JToken token in container.Children())
                {
                    if (((JProperty) token).Name == "data")
                    {
                        return ((JProperty) token).Value.Value<object>();
                    }
                }
            }

            return null;
        }
    }

    [Controller]
    public class CurrencyReportController : ViewerController
    {
        public CurrencyReportController()
        {
        }

        //[HttpPost]
        //public IActionResult GetReportdCurrSales(FilterCurrSaleDto filterPiDto)
        //{
        //    var reoportName = "wwwroot/Reports/Currency/ReportFilterCurrencySale.mrt";
        //    StiRequestParams requestParams = StiAngularViewer.GetRequestParams(this);
        //    return new ViewerController().InitViewer();
        //    //return new ViewerController(filterPiDto, reoportName, requestParams).InitViewer();
        //}
    }
}