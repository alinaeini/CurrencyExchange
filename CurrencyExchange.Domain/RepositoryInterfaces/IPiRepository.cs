using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface IPiRepository : IGenericRepository<PeroformaInvoice>
    {
        bool IsPiExistByCode(string piCode);
    }
}