namespace CurrencyExchange.Core.Dtos.Paging
{
    public interface IFilterListAddedItem<TEntity>
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? FromPrice { get; set; }
        public string? ToPrice { get; set; }
    }
}