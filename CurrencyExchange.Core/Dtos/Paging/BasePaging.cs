namespace CurrencyExchange.Core.Dtos.Paging
{
    public class BasePaging
    {
        public BasePaging()
        {
            PageId = 1;
            TakeEntity = 10;
        }
        //شماره page
        public int PageId { get; set; }
        //تعداد صفحات 
        public int PageCount { get; set; }
        //صفحه فعال 
        public int ActivePage { get; set; }
        //صفحه شروع 
        public int StartPage { get; set; }
        //صفحه پایان 
        public int EndPage { get; set; }
        //چندتا چندتا نشون بده 
        public int TakeEntity { get; set; }
        //از چند تا بپره 
        public int SkipEntity { get; set; }
    }
}
