﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.Sales;
using CurrencyExchange.Domain.RepositoryInterfaces.Generics;

namespace CurrencyExchange.Domain.RepositoryInterfaces
{
    public interface ICurrencySaleRepository:IGenericRepository<CurrencySale>
    {
        Task<CurrencySale> GetCurrencyByIdIncludesCustomerAndBroker(long currSaleId);
    }
}