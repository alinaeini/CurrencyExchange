namespace CurrencyExchange.Core.Sequrity
{
    public interface IPasswordHelper
    {
        string EncodePasswordMd5(string password);
    }
}
