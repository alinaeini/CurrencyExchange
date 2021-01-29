using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.EntityModels.Sales;

namespace CurrencyExchange.Domain.EntityModels.ExchangeDeclaration
{
    public class ExDeclaration:BaseEntity
    {
        #region Properties

        [Display(Name = "شماره سریال اظهارنامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ExchangeDeclarationCode { get; set; }

        [Display(Name = "مقدار درهم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long Price { get; set; }

        [Display(Name = "مقدار تناژ")]
        public long Qty { get; set; }

        [Display(Name = "تاریخ انقضای اظهار نامه")]
        public DateTime ExprireDate { get; set; }

        public bool IsSold { get; set; }

        #endregion

        #region Relatoins

        //public long CurrencySaleDetailId { get; set; }
        public ICollection<CurrencySaleDetailExDec> CurrencySaleDetailExDecs { get; set; }

        #endregion
    }
}
