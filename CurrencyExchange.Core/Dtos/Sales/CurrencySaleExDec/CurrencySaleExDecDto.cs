namespace CurrencyExchange.Core.Dtos.Sales.CurrencySaleExDec
{
    public class CurrencySaleExDecDto
    {
        public long Id { get; set; }
        public long CurrSaleExDecId { get; set; }
        public long Price { get; set; }

        public long ExDeclarationId { get; set; }
        public long CurrencySaleId { get; set; }

    }
}