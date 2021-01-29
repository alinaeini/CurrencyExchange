namespace CurrencyExchange.Core.Dtos.Sales
{
    public enum SalesResult
    {
        Success,
        SumBrokerAccountBalanceIsLowerThanPrice,
        ExDecAccountBalanceIsLowerThanPrice,
        CannotUpdateBrokerAmountBalance,
        CanNotUpdate,
        CanNotDelete,
        CanNotUpdateSoldPiDetailInDataBase,
        CanNotUpdateSoldExDecInDataBase
    }
}