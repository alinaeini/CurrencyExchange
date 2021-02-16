using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.Core.Dtos.BaseFilter
{
    public interface IBaseFilter2
    {

        public long StartPrice { get; set; }
        public long EndPrice { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
       // public int? OrderBy { get; set; }
    }
}
