using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Sales.CurrencySalePi;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Extensions;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class CurrencySaleDetailPiService : ICurrencySaleDetailPiService
    {

        #region Costructor

        private readonly ICurrencySalePiDetailRepository _currPiDetailRepository;
        private readonly ICurrencySaleRepository _currencySaleRepository;
        private readonly IPiRepository _piRepository;
        private readonly IPiDetailRepository _piDetailRepository;

        public CurrencySaleDetailPiService(ICurrencySalePiDetailRepository currPiDetailRepository, ICurrencySaleRepository currencySaleRepository, IPiRepository piRepository, IPiDetailRepository piDetailRepository)
        {
            _currPiDetailRepository = currPiDetailRepository;
            _currencySaleRepository = currencySaleRepository;
            _piRepository = piRepository;
            _piDetailRepository = piDetailRepository;
        }

        #endregion

        #region Filter By PiDetailId

        public async Task<FilterCurrSalePiDto> GetListExDecSalesByPiDetailId(FilterCurrSalePiDto filterDto)
        {
            var asQueryable = _currPiDetailRepository
                .GetEntities()
                .Where(x => x.PeroformaInvoiceDetailId == filterDto.Id)
                .AsQueryable();

            var count = (int)Math.Ceiling(asQueryable.Count() / (double)filterDto.TakeEntity);
            var pager = Pager.Builder(count, filterDto.PageId, filterDto.TakeEntity);
            var list = await asQueryable.Paging(pager).ToListAsync();
            filterDto.CurrencySaleDetailPi = new List<CurrencySaleDetailPiDto>();
            foreach (var item in list)
            {
                var currencySaleItem = await _currencySaleRepository.GetCurrencyByIdIncludesCustomerAndBroker(item.CurrencySaleId);

                var piDetail = await _piRepository.GetEntityById(item.PeroformaInvoiceDetailId??1);
                filterDto.CurrencySaleDetailPi.Add(new CurrencySaleDetailPiDto()
                {
                    Id = item.Id,
                    BrokerName = currencySaleItem.Broker.Name + " ("+ currencySaleItem.Broker.Title + ") " ,
                    CurrSaleDate = currencySaleItem.SaleDate,
                    CustomerName = currencySaleItem.Customer.Name,
                    Price = item.Price,
                    ProfitLossAmount = item.ProfitLossAmount,
                    PiCode = piDetail.PiCode
                });
            }
            return filterDto.SetCurrencySaleExDec(filterDto.CurrencySaleDetailPi).SetPaging(pager);
        }


        #endregion


        #region Filter By CurrencySaleId

        public async Task<FilterCurrSalePiDto> GetListPiSalesByCurrencyId(FilterCurrSalePiDto filterDto)
        {
            var asQueryable = _currPiDetailRepository
                .GetEntities()
                .Where(x => x.CurrencySaleId == filterDto.Id)
                .AsQueryable();
            if (filterDto.SearchText != null || !(string.IsNullOrEmpty(filterDto.SearchText)))
            {
                asQueryable = asQueryable.Include(x => x.PeroformaInvoiceDetails)
                    .Include(c => c.PeroformaInvoiceDetails.PeroformaInvoice)
                    .Where(d =>
                        d.PeroformaInvoiceDetails.PeroformaInvoice.PiCode.Contains(filterDto.SearchText.Trim()));
            }

            var count = (int)Math.Ceiling(asQueryable.Count() / (double)filterDto.TakeEntity);
            var pager = Pager.Builder(count, filterDto.PageId, filterDto.TakeEntity);
            var list = await asQueryable.Paging(pager).ToListAsync();
            filterDto.CurrencySaleDetailPi = new List<CurrencySaleDetailPiDto>();
            foreach (var item in list)
            {
                var currencySaleItem = await _currencySaleRepository.GetCurrencyByIdIncludesCustomerAndBroker(item.CurrencySaleId);

                var piDetail = await _piDetailRepository.GetEntityById(item.PeroformaInvoiceDetailId ?? 1);
                var pi = await _piRepository.GetEntityById(piDetail.PeroformaInvoiceId);
                filterDto.CurrencySaleDetailPi.Add(new CurrencySaleDetailPiDto()
                {
                    Id = item.Id,
                    BrokerName = currencySaleItem.Broker.Name + " (" + currencySaleItem.Broker.Title + ") ",
                    CurrSaleDate = currencySaleItem.SaleDate,
                    CustomerName = currencySaleItem.Customer.Name,
                    Price = item.Price,
                    ProfitLossAmount = item.ProfitLossAmount,
                    PiCode = pi.PiCode,
                    PiDetailPrice=piDetail.DepositPrice
                });
            }
            return filterDto.SetCurrencySaleExDec(filterDto.CurrencySaleDetailPi).SetPaging(pager);
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            _currPiDetailRepository?.Dispose();
            _currencySaleRepository?.Dispose();
            _piRepository?.Dispose();
            _piDetailRepository?.Dispose();
        }
        #endregion

    }
}