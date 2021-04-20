 using CurrencyExchange.Application.Dtos.Paging;

 namespace CurrencyExchange.Core.Dtos.Paging
{
    public  class Pager
    {
        public static BasePaging Builder(int pageCount, int pageNumber, int take)
        {

            pageNumber =( pageNumber <= 1) ? 1 : pageNumber;
            pageNumber = (pageNumber > pageCount) ? 1 : pageNumber;
            return  new BasePaging
            {
               ActivePage = pageNumber , 
               PageCount = pageCount,
               PageId = pageNumber , 
               TakeEntity = take ,
               SkipEntity =  (pageNumber -1 ) * take,
               StartPage = (pageNumber - 3) <=0  ? 1 :  (pageNumber - 3),
               EndPage = (pageNumber + 3) >= pageCount  ? pageCount :  (pageNumber + 3)
            };
        }
    }
}
