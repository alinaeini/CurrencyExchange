using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Core.Dtos.Broker
{
    public class BrokerDto
    {
        #region Properties

        public long Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Description { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Tel { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(500,ErrorMessage = "تعداد کاراکترهای {0} نمیتواند بیشتر از {1} باشد")]
        public string Address { get; set; }

        [Display(Name = "نرخ کارمزد تو حسابی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType("decimal(6 ,3)")]
        public decimal ServiceChargeAccount { get; set; }

        [Display(Name = "نرخ کارمزد نقدی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType("decimal(6 ,3)")]
        public decimal ServiceChargeCash { get; set; }


        [Display(Name = "موجودی حساب")]
        public long AccountBalance { get; set; }

        #endregion
    }
}
