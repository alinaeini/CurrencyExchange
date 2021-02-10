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

        private readonly IExDeclarationRepository _declarationRepository;
        private readonly ICurrencySaleRepository _currencySaleRepository;
        private readonly ICurrencySaleExDecRepository _currencySaleExDecRepository;

        public CurrencySaleDetailExDecService(IExDeclarationRepository declarationRepository, ICurrencySaleRepository currencySaleRepository, ICurrencySaleExDecRepository currencySaleExDecRepository)
        {
            _declarationRepository = declarationRepository;
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
                var currencySaleItem = await _currencySaleRepository.GetByIdIncludes(item.CurrencySaleId);

                var exDec = await _declarationRepository.GetEntityById(item.ExDeclarationId);
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

            var asQueryable = _currencySaleExDecRepository
                .GetEntities()
                .Where(x => x.CurrencySaleId == filterDto.Id)
                .AsQueryable();
            var count = (int)Math.Ceiling(asQueryable.Count() / (double)filterDto.TakeEntity);
            var pager = Pager.Builder(count, filterDto.PageId, filterDto.TakeEntity);
            var list = await asQueryable.Paging(pager).ToListAsync();
            filterDto.CurrencySaleExDecs = new List<CurrencySaleExDecDto>();
            foreach (var item in list)
            {
                var currencySaleItem = await _currencySaleRepository.GetByIdIncludes(item.CurrencySaleId);

                filterDto.CurrencySaleExDecs.Add(new CurrencySaleExDecDto()
                {
                    Id = item.Id,
                    CurrSaleDate = currencySaleItem.SaleDate,
                    BrokerName = currencySaleItem.Broker.Name + " (" + currencySaleItem.Broker.Title + ") ",
                    CustomerName = currencySaleItem.Customer.Name,
                    ExDecCode = item.ExDeclaration.ExchangeDeclarationCode,
                    Price = item.Price
                });
            }
            return filterDto.SetCurrencySaleExDec(filterDto.CurrencySaleExDecs).SetPaging(pager);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _declarationRepository?.Dispose();
            _currencySaleRepository?.Dispose();
            _currencySaleExDecRepository?.Dispose();
        }



        #endregion

    }
}