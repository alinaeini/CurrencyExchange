using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Pi.PiDetail;
using CurrencyExchange.Core.Dtos.Sales.CurrencySaleExDec;
using CurrencyExchange.Core.Dtos.Sales.CurrencySalePi;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Extensions;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class CurrencySaleDetailExDecService : ICurrencySaleDetailExDecService
    {

        #region Costructor

        private readonly IExDeclarationRepository _exdeclarationRepository;
        private readonly ICurrencySaleRepository _currencySaleRepository;
        private readonly ICurrencySaleExDecRepository _currencySaleExDecRepository;

        public CurrencySaleDetailExDecService(IExDeclarationRepository exdeclarationRepository, ICurrencySaleRepository currencySaleRepository, ICurrencySaleExDecRepository currencySaleExDecRepository)
        {
            _exdeclarationRepository = exdeclarationRepository;
            _currencySaleRepository = currencySaleRepository;
            _currencySaleExDecRepository = currencySaleExDecRepository;
        }



        #endregion 

        #region Filter on Curr Sale ExDec Id

        public async Task<FilterCurrSaleExDecDto> GetListExDecSalesByExdecId(FilterCurrSaleExDecDto filterDto)
        {

            var asQueryable =  _currencySaleExDecRepository
                .GetEntities()
                .Where(x=>x.ExDeclarationId == filterDto.Id)
                .AsQueryable();
            var count = (int)Math.Ceiling(asQueryable.Count() / (double)filterDto.TakeEntity);
            var pager = Pager.Builder(count, filterDto.PageId, filterDto.TakeEntity);
            var list = await asQueryable.Paging(pager).ToListAsync();
            filterDto.CurrencySaleExDecs = new List<CurrencySaleExDecDto>();
            foreach (var item in list)
            {
                var currencySaleItem = await _currencySaleRepository.GetCurrencyByIdIncludesCustomerAndBroker(item.CurrencySaleId);

                var exDec = await _exdeclarationRepository.GetEntityById(item.ExDeclarationId);
                filterDto.CurrencySaleExDecs.Add(new CurrencySaleExDecDto()
                {
                    Id=item.Id,
                    CurrSaleDate = currencySaleItem.SaleDate,
                    BrokerName = currencySaleItem.Broker.Name + " ("+ currencySaleItem.Broker.Title + ") " ,
                    CustomerName = currencySaleItem.Customer.Name,
                    ExDecCode = exDec.ExchangeDeclarationCode,
                    Price = item.Price
                });
            }
            return filterDto.SetCurrencySaleExDec(filterDto.CurrencySaleExDecs).SetPaging(pager);
        }




        #endregion

        #region Filter on Curr Sale Currency Sale Id

        public async Task<FilterCurrSaleExDecDto> GetListExDecSalesByCurrencyId(FilterCurrSaleExDecDto filterDto)
        {

            var currencyExdecAsQueryable = _currencySaleExDecRepository
                .GetEntities()
                .Where(x => x.CurrencySaleId == filterDto.Id)
                .AsQueryable();
            if (filterDto.SearchText != null || !(string.IsNullOrEmpty(filterDto.SearchText)))
            {
                currencyExdecAsQueryable = currencyExdecAsQueryable
                    .Include(s => s.CurrencySale)
                    .Include(x => x.CurrencySale.Customer)
                    .Include(c => c.CurrencySale.Broker)
                    .Include(c => c.ExDeclaration)
                    .Where(x => x.CurrencySale.Customer.Name.Contains(filterDto.SearchText.Trim()) ||
                                x.CurrencySale.Customer.Title.Contains(filterDto.SearchText.Trim()) ||
                                x.CurrencySale.Broker.Name.Contains(filterDto.SearchText.Trim()) ||
                                x.ExDeclaration.ExchangeDeclarationCode.Contains(filterDto.SearchText.Trim())
                                );

            }
            var count = (int)Math.Ceiling(currencyExdecAsQueryable.Count() / (double)filterDto.TakeEntity);
            var pager = Pager.Builder(count, filterDto.PageId, filterDto.TakeEntity);
            var list = await currencyExdecAsQueryable.Paging(pager).ToListAsync();
            filterDto.CurrencySaleExDecs = new List<CurrencySaleExDecDto>();
            foreach (var item in list)
            {
                var currencySaleItem = await _currencySaleRepository.GetCurrencyByIdIncludesCustomerAndBroker(item.CurrencySaleId);
                var exDec = await _exdeclarationRepository.GetEntityById(item.ExDeclarationId);
                filterDto.CurrencySaleExDecs.Add(new CurrencySaleExDecDto()
                {
                    Id = item.Id,
                    CurrSaleDate = currencySaleItem.SaleDate,
                    BrokerName = currencySaleItem.Broker.Name + " (" + currencySaleItem.Broker.Title + ") ",
                    CustomerName = currencySaleItem.Customer.Name,
                    ExDecCode = exDec.ExchangeDeclarationCode,
                    ExDecPrice=exDec.Price,
                    Price = item.Price
                });
            }
            return filterDto.SetCurrencySaleExDec(filterDto.CurrencySaleExDecs).SetPaging(pager);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _exdeclarationRepository?.Dispose();
            _currencySaleRepository?.Dispose();
            _currencySaleExDecRepository?.Dispose();
        }



        #endregion

    }
}