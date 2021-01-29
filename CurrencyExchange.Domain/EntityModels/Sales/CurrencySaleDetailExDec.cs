using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CurrencyExchange.Domain.EntityModels.Common;
using CurrencyExchange.Domain.EntityModels.ExchangeDeclaration;

namespace CurrencyExchange.Domain.EntityModels.Sales
{
    public class CurrencySaleDetailExDec :BaseEntity
    {
        #region Properties

        [Display(Name = "مقدار ارز فروش رفته ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public long Price { get; set; }

        public long ExDeclarationId { get; set; }
        public long CurrencySaleId { get; set; }

        

        #endregion

        #region Relatoins

        public ExDeclaration ExDeclaration { get; set; }
        

        #endregion
    }
}
