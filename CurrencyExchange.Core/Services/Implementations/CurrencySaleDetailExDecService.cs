using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //private readonly ICurrencySaleRepository _currencySaleRepository;
        private readonly ICurrencySaleExDecRepository _currencySaleExDecRepository;

        public CurrencySaleDetailExDecService(ICurrencySaleExDecRepository currencySaleExDecRepository)
        {
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
                filterDto.CurrencySaleExDecs.Add(new CurrencySaleExDecDto()
                {
                    Id=item.Id,
                    CurrSaleExDecId = item.Id,
                    CurrencySaleId = item.CurrencySaleId,
                    ExDeclarationId = item.ExDeclarationId,
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
                filterDto.CurrencySaleExDecs.Add(new CurrencySaleExDecDto()
                {
                    Id = item.Id,
                    CurrSaleExDecId = item.Id,
                    CurrencySaleId = item.CurrencySaleId,
                    ExDeclarationId = item.ExDeclarationId,
                    Price = item.Price
                });
            }
            return filterDto.SetCurrencySaleExDec(filterDto.CurrencySaleExDecs).SetPaging(pager);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _currencySaleExDecRepository?.Dispose();
        }



        #endregion

    }
}