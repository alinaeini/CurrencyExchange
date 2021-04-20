using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurrencyExchange.Core.Dtos.ExDecalaration
{
     public class CreateExDecDto
    {
        #region Properties

        [Display(Name = "شماره سریال اظهارنامه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ExCode { get; set; }

        [Display(Name = "مقدار درهم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long Price { get; set; }

        [Display(Name = "مقدار تناژ")]
        public long Qty { get; set; }

        [Display(Name = "تاریخ انقضای اظهار نامه")]
        public DateTime ExpireDate { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        #endregion
    }
}
