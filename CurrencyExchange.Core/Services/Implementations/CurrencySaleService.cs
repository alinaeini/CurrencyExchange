using System;
using CurrencyExchange.Core.Dtos.Sales;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Domain.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Customer;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Sales.CurrencySalePi;
using CurrencyExchange.Core.Sequrity;
using CurrencyExchange.Core.Utilities.Extensions;
using CurrencyExchange.Domain.EntityModels.Currency;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class CurrencySaleService : ICurrencySaleService
    {

        #region Costructor

        private readonly ICurrencySaleRepository _saleRepository;
        private readonly ICurrencySalePiDetailRepository _salePiDetailRepository;
        private readonly ICurrencySaleExDecRepository _saleExDecRepository;
        private readonly IExDeclarationRepository _declarationRepository;
        private readonly IPiDetailRepository _piDetailRepository;
        private readonly IBrokerRepository _brokerRepository;
        private readonly ICustomerRepository _customerRepository;

        public CurrencySaleService(ICurrencySaleRepository saleRepository, ICurrencySalePiDetailRepository salePiDetailRepository, ICurrencySaleExDecRepository saleExDecRepository, IExDeclarationRepository declarationRepository, IPiDetailRepository piDetailRepository, IBrokerRepository brokerRepository, ICustomerRepository customerRepository)
        {
            _saleRepository = saleRepository;
            _salePiDetailRepository = salePiDetailRepository;
            _saleExDecRepository = saleExDecRepository;
            _declarationRepository = declarationRepository;
            _piDetailRepository = piDetailRepository;
            _brokerRepository = brokerRepository;
            _customerRepository = customerRepository;
        }

        #endregion

        #region Insert Into CurrencySale

        public async Task<SalesResult> Create(CreateSaleDto createPiDto)
        {
            var result = await ValidationBeforCreateCurrencySales(createPiDto);
            if (result == SalesResult.Success)
            {

                #region Create Currency Sale

                var currencySale = new CurrencySale()
                {
                    SaleDate = createPiDto.SaleDate,
                    SalePrice = createPiDto.SalePrice,
                    SalePricePerUnit = createPiDto.SalePricePerUnit,
                    BrokerId = createPiDto.BrokerId,
                    CustomerId = createPiDto.CustomerId,
                    TransferType = (CurrencyTransferType)createPiDto.TransferType,
                    TransferPrice = createPiDto.TransferPrice,
                    Description = createPiDto.Description
                };
                await _saleRepository.AddEntity(currencySale);
                #endregion

                #region Insert Data To CurrencySalesDetail By System

                var resulTask = await FillAutomaticCurrSaleDetail(createPiDto, currencySale);
                if (resulTask != SalesResult.Success)
                {

                    return resulTask;
                }

                #endregion
            }


            await _saleRepository.SaveChanges();
            return result;
        }

        #endregion

        #region Filter Currency Sale 

        public async Task<FilterCurrSaleDto> GetListSales(FilterCurrSaleDto filterDto)
        {
            var currencyAsQueryable = _saleRepository
                .GetEntities()
                .AsQueryable();

            #region Set Filters

            #region Filter - SearchText

            if (filterDto.SearchText != null || !(string.IsNullOrEmpty(filterDto.SearchText)))
            {
                currencyAsQueryable = currencyAsQueryable
                    .Include(x => x.Customer)
                    .Include(c => c.Broker)
                    .Where(x => x.Customer.Name.Contains(filterDto.SearchText.Trim()) ||
                                x.Customer.Title.Contains(filterDto.SearchText.Trim()) ||
                                x.Broker.Name.Contains(filterDto.SearchText.Trim())
                    );

            }

            #endregion

            #region Filter - Transfer Type(s)

            if (filterDto.IsAccount)
                currencyAsQueryable = currencyAsQueryable.Where(x => x.TransferType == CurrencyTransferType.Accounting);
            if (filterDto.IsCashed)
                currencyAsQueryable = currencyAsQueryable.Where(x => x.TransferType == CurrencyTransferType.Cash);

            #endregion

            #region Filter - From To Sale Date 

            if (!string.IsNullOrWhiteSpace(filterDto.FromDateSale))
                currencyAsQueryable = currencyAsQueryable.Where(x => x.SaleDate >= Convert.ToDateTime(filterDto.FromDateSale));
            if (!string.IsNullOrWhiteSpace(filterDto.ToDateSale))
                currencyAsQueryable = currencyAsQueryable.Where(x => x.SaleDate < Convert.ToDateTime(filterDto.ToDateSale));

            #endregion

            #region Filter - From To Price

            if (filterDto.FromSaleBasePrice != 0)
                currencyAsQueryable = currencyAsQueryable.Where(s => s.SalePricePerUnit >= filterDto.FromSaleBasePrice);

            if (filterDto.ToSaleBasePrice != 0)
                currencyAsQueryable = currencyAsQueryable.Where(s => s.SalePricePerUnit <= filterDto.ToSaleBasePrice);

            #endregion

            #region Filter - Broker
            if (filterDto.BrokerId > 0)
                currencyAsQueryable = currencyAsQueryable.Where(s => s.BrokerId == filterDto.BrokerId);
            #endregion

            #region Filter - Customer

            if (filterDto.CustomerId > 0)
                currencyAsQueryable = currencyAsQueryable.Where(s => s.CustomerId == filterDto.CustomerId);

            #endregion

            #endregion

            var count = (int)Math.Ceiling(currencyAsQueryable.Count() / (double)filterDto.TakeEntity);
            var pager = Pager.Builder(count, filterDto.PageId, filterDto.TakeEntity);
            var list = await currencyAsQueryable.Paging(pager).ToListAsync();
            filterDto.Entities = new List<CurrencySaleDto>();
            foreach (var item in list)
            {
                var currencySaleItem = await _saleRepository.GetCurrencyByIdIncludesCustomerAndBroker(item.Id);

                var sumProfit = await _salePiDetailRepository.GetSumProfitLost(item.Id);
                filterDto.Entities.Add(new CurrencySaleDto
                {
                    Id = item.Id,
                    BrokerName = currencySaleItem.Broker.Name + " (" + currencySaleItem.Broker.Title + ") ",
                    CurrSaleDate = currencySaleItem.SaleDate,
                    CustomerName = currencySaleItem.Customer.Name,
                    Price = item.SalePrice,
                    ProfitLossAmount = sumProfit,
                    SalePricePerUnit = item.SalePricePerUnit,
                    TransferPrice = item.TransferPrice,
                    TransferType = item.TransferType
                });
            }
            return (FilterCurrSaleDto) filterDto.SetEntitiesDto(filterDto.Entities).SetPaging(pager);
        }

        #endregion

        #region Filter Currency Sale By CustomerId

        public async Task<FilterCurrSaleCustomerListDto> GetListSalesByCustomerId(long customerId)
        {
            var filterOutput = new FilterCurrSaleCustomerListDto();
            var currencyAsQueryable = _saleRepository
                .GetEntities()
                .Where(x=>x.CustomerId == customerId)
                .AsQueryable();

            var count = (int)Math.Ceiling(currencyAsQueryable.Count() / (double)filterOutput.TakeEntity);
            var pager = Pager.Builder(count, filterOutput.PageId, filterOutput.TakeEntity);
            var list = await currencyAsQueryable.Paging(pager).ToListAsync();
            filterOutput.Entities = new List<CurrencySaleDto>();
            foreach (var item in list)
            {
                var currencySaleItem = await _saleRepository.GetCurrencyByIdIncludesCustomerAndBroker(item.Id);

                var sumProfit = await _salePiDetailRepository.GetSumProfitLost(item.Id);
                filterOutput.Entities.Add(new CurrencySaleDto
                {
                    Id = item.Id,
                    BrokerName = currencySaleItem.Broker.Name + " (" + currencySaleItem.Broker.Title + ") ",
                    CurrSaleDate = currencySaleItem.SaleDate,
                    CustomerName = currencySaleItem.Customer.Name,
                    Price = item.SalePrice,
                    ProfitLossAmount = sumProfit,
                    SalePricePerUnit = item.SalePricePerUnit,
                    TransferPrice = item.TransferPrice,
                });
            }
            return (FilterCurrSaleCustomerListDto) filterOutput.SetEntitiesDto(filterOutput.Entities).SetPaging(pager);
        }

        #endregion

        #region Filter Currency Sold Per Custoemr 
        public async Task<FilterCurrencyCustomerDto> GetSoldPerCustomers(FilterCurrencyCustomerDto filterDto)
        {
            var asQueryableEntity = _customerRepository
                .GetEntities()
                .Include(x=>x.CurrencySale)
                .Where(c=> c.CurrencySale.Any(x=>x.CustomerId == c.Id))
                .AsQueryable();
            if (filterDto.SearchText != null || !(string.IsNullOrEmpty(filterDto.SearchText)))
            {
                asQueryableEntity = asQueryableEntity.Where(x => x.Title.Contains(filterDto.SearchText.Trim()) ||
                                                                 x.Name.Contains(filterDto.SearchText.Trim()));
            }
            var count = (int)Math.Ceiling(asQueryableEntity.Count() / (double)filterDto.TakeEntity);
            var pager = Pager.Builder(count, filterDto.PageId, filterDto.TakeEntity);
            var list = await asQueryableEntity.Paging(pager).ToListAsync();
            filterDto.Entities = new List<CurrencyCustomerDto>();
            foreach (var item in list)
            {
                var totalBuy = await _saleRepository.GetTotalCurrencyByCustomerId(item.Id);
                if (totalBuy > 0)
                    filterDto.Entities.Add(new CurrencyCustomerDto()
                    {
                        Title = item.Title.SanitizeText(),
                        Name = item.Name.SanitizeText(),
                        Phone = item.Phone.SanitizeText(),
                        Address = item.Address.SanitizeText(),
                        Id = item.Id,
                        SoldAmount = totalBuy
                    });
            }
            return (FilterCurrencyCustomerDto)filterDto.SetEntitiesDto(filterDto.Entities).SetPaging(pager);
        }
        #endregion

        #region Utility Methods

        #region FillAutomaticCurrSaleDetail

        private async Task<SalesResult> FillAutomaticCurrSaleDetail(CreateSaleDto saleDto, CurrencySale currencySales)
        {

            Boolean isExDecAutomatic;
            #region Get List Of PiDetails That Is Not Sold Yet

            var piDetails = await _piDetailRepository.GetAccountBalanceByDetailsByBrokerId(saleDto.BrokerId);

            #endregion

            #region Get List Of ExDeclaration List That Is Not Sold Yet

            var exDecList = new List<ExDecExport>();
            if (saleDto.ExDecExport.Count > 0)
            {
                isExDecAutomatic = false;
                exDecList = saleDto.ExDecExport;
            }
            else
            {
                isExDecAutomatic = true;
                var lisexDecList = await _declarationRepository.GetExDecAccountBalanceByExDecId();
                foreach (var item in lisexDecList)
                {
                    exDecList.Add(new ExDecExport { Id = item.Id, Price = item.Price, ExCode = item.ExchangeDeclarationCode });
                }
            }

            #endregion

            #region Insert Into  CurrencySalePi And CurrencySaleDetailExDec

            if (isExDecAutomatic)
            {
                var saleexDecResult = await InserSaleCurrExDecAutomatic(exDecList, saleDto, currencySales);
                if (saleexDecResult != SalesResult.Success)
                    return saleexDecResult;
            }
            else
            {
                var saleexDecResult = await InserSaleCurrExDecManual(exDecList, saleDto, currencySales);
                if (saleexDecResult != SalesResult.Success)
                    return saleexDecResult;
            }


            var salePiDetailResult = await InserSaleCurrPiDetail(piDetails, saleDto, currencySales);
            if (salePiDetailResult != SalesResult.Success)
                return salePiDetailResult;

            #endregion

            return SalesResult.Success;
        }

        #endregion

        #region Insert Into CurrencySaleDetailExDec

        private async Task<SalesResult> InserSaleCurrExDecAutomatic(List<ExDecExport> exDecList, CreateSaleDto saleDto, CurrencySale currencySales)
        {
            long totalInserted = 0;
            foreach (var exdec in exDecList)
            {
                #region Validation - ExDec Price Is Ok

                var exdecEntity = await _declarationRepository.GetEntityById(exdec.Id);
                var usedPriceOfExdecCode = await _saleExDecRepository.GetSumExCodeUsedById(exdec.Id);
                var remaindPriceOfExdecCode = exdec.Price - (usedPriceOfExdecCode);
                //if (exdecEntity.Price < exdec.Price)
                //{
                //    return SalesResult.ExDecAccountBalanceIsLowerThanPrice;
                //}

                //if (exdec.Price < remaindPriceOfExdecCode)
                //{
                //    return SalesResult.ExDecAccountBalanceIsLowerThanPrice;
                //}

                long price;
                if (exdec.Price >= remaindPriceOfExdecCode)
                {
                    price = remaindPriceOfExdecCode;
                }
                else
                {
                    price = exdec.Price;
                }

                if (price + totalInserted > saleDto.SalePrice)
                {
                    price = saleDto.SalePrice - totalInserted;
                }
                #endregion

                #region Insert Into CurrencySaleDetailExDec

                var currencySaleDetailEx = new CurrencySaleDetailExDec
                {
                    CurrencySale = currencySales,
                    Price = price,
                    ExDeclarationId = exdec.Id
                };
                await _saleExDecRepository.AddEntity(currencySaleDetailEx);
                //await _saleExDecRepository.SaveChanges();

                #endregion



                #region Update Sold In ExDeclaration
                if (price + usedPriceOfExdecCode >= exdecEntity.Price)
                {
                    var updateSoldExdec = await _declarationRepository.SoldedDeclaration(exdecEntity.Id);
                    if (!updateSoldExdec)
                        return SalesResult.CanNotUpdateSoldExDecInDataBase;
                }

                #endregion

                totalInserted += price;
                if (totalInserted == saleDto.SalePrice)
                {
                    return SalesResult.Success;
                }
            }

            return SalesResult.Success;
        }

        private async Task<SalesResult> InserSaleCurrExDecManual(List<ExDecExport> exDecList, CreateSaleDto saleDto, CurrencySale currencySales)
        {
            long totalInserted = 0;
            foreach (var exdecItem in exDecList)
            {
                #region Validation - ExDec Price Is Ok

                var exdecEntity = await _declarationRepository.GetEntityById(exdecItem.Id);
                var usedPriceOfExdecCode = await _saleExDecRepository.GetSumExCodeUsedById(exdecItem.Id);
                var remaindPriceOfExdecCode = exdecEntity.Price - usedPriceOfExdecCode;
                //if (exdecEntity.Price < exdec.Price)
                //{
                //    return SalesResult.ExDecAccountBalanceIsLowerThanPrice;
                //}

                //if (exdec.Price < remaindPriceOfExdecCode)
                //{
                //    return SalesResult.ExDecAccountBalanceIsLowerThanPrice;
                //}

                long price;

                if (exdecItem.Price >= remaindPriceOfExdecCode)
                {
                    price = remaindPriceOfExdecCode + (exdecItem.Price - remaindPriceOfExdecCode);
                }
                else
                {
                    price = exdecItem.Price;
                }

                //if (exdecItem.Price + totalInserted > saleDto.SalePrice)
                //{
                //    price = saleDto.SalePrice - totalInserted;
                //}
                #endregion

                #region Insert Into CurrencySaleDetailExDec

                var currencySaleDetailEx = new CurrencySaleDetailExDec
                {
                    CurrencySale = currencySales,
                    Price = price,
                    ExDeclarationId = exdecItem.Id
                };
                await _saleExDecRepository.AddEntity(currencySaleDetailEx);
                //await _saleExDecRepository.SaveChanges();

                #endregion



                #region Update Sold In ExDeclaration
                if (exdecItem.Price + usedPriceOfExdecCode >= exdecEntity.Price)
                {
                    var updateSoldExdec = await _declarationRepository.SoldedDeclaration(exdecEntity.Id);
                    if (!updateSoldExdec)
                        return SalesResult.CanNotUpdateSoldExDecInDataBase;
                }

                #endregion

                totalInserted += exdecItem.Price;
                if (totalInserted == saleDto.SalePrice)
                {
                    return SalesResult.Success;
                }
            }

            return SalesResult.Success;
        }

        #endregion

        #region Insert Into CurrencySaleDetailPi

        private async Task<SalesResult> InserSaleCurrPiDetail(List<PeroformaInvoiceDetail> peroformaInvoiceDetails, CreateSaleDto saleDto, CurrencySale currencySales)
        {
            long totalInserted = 0;
            foreach (var piDetailDto in peroformaInvoiceDetails)
            {
                #region Validation - PiDetail Price Is Ok

                var usedPriceOfPiCode = await _salePiDetailRepository.GetSumPiCodeUsedById(piDetailDto.Id);
                var remaindPriceOfPiCode = piDetailDto.DepositPrice - usedPriceOfPiCode;
                var priceOfSales = saleDto.SalePrice + saleDto.TransferPrice;
                //if (piDetailDto.DepositPrice < remaindPriceOfExdecCode)
                //{
                //    return SalesResult.PiAccountBalanceIsLowerThanPrice;
                //}

                long price;
                long profit;
                var piBasePrice = piDetailDto.PeroformaInvoice.BasePrice;
                if (priceOfSales >= remaindPriceOfPiCode)
                    price = remaindPriceOfPiCode;
                else
                    price = piDetailDto.DepositPrice;

                if (price + totalInserted > priceOfSales)
                {
                    price = priceOfSales - totalInserted;
                    profit = (saleDto.SalePricePerUnit - piBasePrice) * (price - saleDto.TransferPrice);
                }
                else
                {
                    profit = (saleDto.SalePricePerUnit - piBasePrice) * price;
                }




                #endregion

                #region MyRegion

                var currencySaleDetailPi = new CurrencySaleDetailPi()
                {
                    CurrencySale = currencySales,
                    Price = price,
                    ProfitLossAmount = profit,
                    PeroformaInvoiceDetailId = piDetailDto.Id
                };
                await _salePiDetailRepository.AddEntity(currencySaleDetailPi);
                //await _salePiDetailRepository.SaveChanges();

                #endregion

                #region Update Sold In PiDetail

                if (price + usedPriceOfPiCode == piDetailDto.DepositPrice)
                {
                    var updateSold = await _piDetailRepository.SoldedPiDetail(piDetailDto.Id);
                    if (!updateSold)
                        return SalesResult.CanNotUpdateSoldPiDetailInDataBase;
                }

                var updateBrokerAmount = await _brokerRepository.UpdateBrokerAmount(saleDto.BrokerId, price, false);
                if (!updateBrokerAmount)
                    return SalesResult.CannotUpdateBrokerAmountBalance;
                #endregion

                totalInserted += price;
                if (totalInserted == priceOfSales)
                {
                    return SalesResult.Success;
                }
            }

            return SalesResult.Success;
        }

        #endregion

        #region Validation(s)

        #region Validation Befor Create CurrencySale -master

        private async Task<SalesResult> ValidationBeforCreateCurrencySales(CreateSaleDto createPiDto)
        {
            //var sumExDec = await _declarationRepository.GetSumExDecAccountBalance();
            //if (createPiDto.SalePrice > sumExDec)
            //{
            //    return SalesResult.ExDecAccountBalanceIsLowerThanPrice;
            //}

            var sumPiDetail = await _piDetailRepository.GetSumBrokerAccountBalance(createPiDto.BrokerId);
            if (createPiDto.SalePrice > sumPiDetail)
            {
                return SalesResult.SumBrokerAccountBalanceIsLowerThanPrice;
            }

            return SalesResult.Success;
        }

        #endregion

        #endregion

        #endregion

        #region Dispose

        public void Dispose()
        {
            _saleRepository?.Dispose();
            _salePiDetailRepository?.Dispose();
            _saleExDecRepository?.Dispose();
            _declarationRepository?.Dispose();
            _piDetailRepository?.Dispose();
            _brokerRepository?.Dispose();
            _customerRepository?.Dispose();
        }

        #endregion

    }
}