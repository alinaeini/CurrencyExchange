using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurrencyExchange.Core.Dtos.Sales
{
    public class CreateSaleDto
    {
        #region Properties

        [Display(Name = " تاریخ فروش ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime SaleDate { get; set; }

        [Display(Name = "مقدار ارز فروش رفته ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long SalePrice { get; set; }

        [Display(Name = "نرخ فروش ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long SalePricePerUnit { get; set; }

        [Display(Name = "نوع انتقال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long TransferType { get; set; }

        [Display(Name = "کارمزد انتقال ارز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long TransferPrice { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Description { get; set; }

        public long BrokerId { get; set; }
        public long CustomerId { get; set; }
        [Display(Name = "لیست اظهارنامه ها")] 
        public List<ExDecExport> ExDecExport { get; set; }

        #endregion
    }
}