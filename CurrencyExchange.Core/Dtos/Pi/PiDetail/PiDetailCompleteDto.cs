using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Application.Dtos.Pi.PiDetail
{
    public class PiDetailCompleteDto
    {
        #region Properties
        public long Id { get; set; }

        [Display(Name = "مبلغ واریزی")]
        public long DepositPrice { get; set; }

        [Display(Name = "تاریخ واریزی")]
        public DateTime DepositDate { get; set; }

        public bool IsSold { get; set; }

        public string PiCode { get; set; }

        public string BrokerName { get; set; }

        public long TotalPrice { get; set; }

        public string CustomerName { get; set; }

        #endregion

        #region Relations

        public long PiId { get; set; }

        public long BrokerId { get; set; }

        #endregion
    }
}