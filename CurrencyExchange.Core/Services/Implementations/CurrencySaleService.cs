using CurrencyExchange.Core.Dtos.Sales;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Domain.EntityModels.Sales;
using CurrencyExchange.Domain.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class CurrencySaleService : ICurrencySaleService
    {

        #region Costructor

        private ICurrencySaleRepository _saleRepository;
        private ICurrencySalePiDetailRepository _salePiDetailRepository;
        private ICurrencySaleExDecRepository _saleExDecRepository;
        private IExDeclarationRepository _declarationRepository;
        private IPiDetailRepository _piDetailRepository;
        private IBrokerRepository _brokerRepository;

        public CurrencySaleService(ICurrencySaleRepository saleRepository, ICurrencySalePiDetailRepository salePiDetailRepository, ICurrencySaleExDecRepository saleExDecRepository, IExDeclarationRepository declarationRepository, IPiDetailRepository piDetailRepository, IBrokerRepository brokerRepository)
        {
            _saleRepository = saleRepository;
            _salePiDetailRepository = salePiDetailRepository;
            _saleExDecRepository = saleExDecRepository;
            _declarationRepository = declarationRepository;
            _piDetailRepository = piDetailRepository;
            _brokerRepository = brokerRepository;
        }

        #endregion

        #region Insert Into CurrencySale

        public async Task<SalesResult> Create(CreateSaleDto createPiDto)
        {
            var result = await ValidationBeforCreateCurrencySales(createPiDto);
            if (result  == SalesResult.Success)
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
                //var insertedCurrencySale = await _saleRepository.CustomeAddEntity(currencySale);
                await _saleRepository.AddEntity(currencySale);
                await _saleRepository.SaveChanges();

                #endregion

                #region Insert Data To CurrencySalesDetail By System

                var resulTask = await FillAutomaticCurrSaleDetail(createPiDto, currencySale.Id);
                if (resulTask != SalesResult.Success)
                {
                    return resulTask;
                }

                #endregion
            }
            return result;
        }

        #endregion

        #region Utility Methods

        #region FillAutomaticCurrSaleDetail

        private async Task<SalesResult> FillAutomaticCurrSaleDetail(CreateSaleDto saleDto, long currencySalesId)
        {


            #region Get List Of PiDetails That Is Not Sold Yet

            var piDetails = await _piDetailRepository.GetAccountBalanceByDetailsByBrokerId(saleDto.BrokerId);

            #endregion

            #region Get List Of ExDeclaration List That Is Not Sold Yet

            var exDecList = new List<ExDecExport>();
            if (saleDto.ExDecExport.Count > 0)
            {
                exDecList = saleDto.ExDecExport;
            }
            else
            {
                var lisexDecList = await _declarationRepository.GetExDecAccountBalanceByExDecId();
                foreach (var item in lisexDecList)
                {
                    exDecList.Add(new ExDecExport { Id = item.Id, Price = item.Price, ExCode = item.ExchangeDeclarationCode });
                }
            }

            #endregion

            #region Insert Into  CurrencySalePi And CurrencySaleDetailExDec

            var saleexDecResult = await InserSaleCurrExDec(exDecList, saleDto, currencySalesId);
            if (saleexDecResult != SalesResult.Success)
                return saleexDecResult;

            var salePiDetailResult = await InserSaleCurrPiDetail(piDetails, saleDto, currencySalesId);
            if (salePiDetailResult != SalesResult.Success)
                return salePiDetailResult;

            #endregion

            return SalesResult.Success;
        }

        #endregion

        #region Insert Into CurrencySaleDetailExDec

        private async Task<SalesResult> InserSaleCurrExDec(List<ExDecExport> exDecList, CreateSaleDto saleDto, long currencySalesId)
        {
            long totalInserted = 0;
            foreach (var exdec in exDecList)
            {
                #region Validation - ExDec Price Is Ok

                var exdecEntity = await _declarationRepository.GetEntityById(exdec.Id);
                var usedPriceOfExdecCode = await _saleExDecRepository.GetSumExCodeUsedById(exdec.Id);
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
                    CurrencySaleId = currencySalesId,
                    Price = price,
                    ExDeclarationId = exdec.Id
                };
                 await _saleExDecRepository.AddEntity(currencySaleDetailEx);
                await _saleExDecRepository.SaveChanges();

                #endregion

               

                #region Update Sold In ExDeclaration
                if (price + usedPriceOfExdecCode == exdecEntity.Price)
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

        #endregion

        #region Insert Into CurrencySaleDetailPi

        private async Task<SalesResult> InserSaleCurrPiDetail(List<PeroformaInvoiceDetail> peroformaInvoiceDetails, CreateSaleDto saleDto, long currencySalesId)
        {
            long totalInserted = 0;
            foreach (var piDetailDto in peroformaInvoiceDetails)
            {
                #region Validation - PiDetail Price Is Ok

                var usedPriceOfExdecCode = await _salePiDetailRepository.GetSumPiCodeUsedById(piDetailDto.Id);
                var remaindPriceOfExdecCode = piDetailDto.DepositPrice - usedPriceOfExdecCode;
                //if (piDetailDto.DepositPrice < remaindPriceOfExdecCode)
                //{
                //    return SalesResult.PiAccountBalanceIsLowerThanPrice;
                //}

                long price;
                long profit;
                if ( saleDto.SalePrice >= remaindPriceOfExdecCode)
                    price = remaindPriceOfExdecCode;
                else
                    price = piDetailDto.DepositPrice;

                if (price + totalInserted > saleDto.SalePrice)
                {
                    price = saleDto.SalePrice - totalInserted;
                }

                var piBasePrice =  piDetailDto.PeroformaInvoice.BasePrice;
                profit = (saleDto.SalePricePerUnit - piBasePrice) * price;

                #endregion

                #region MyRegion

                var currencySaleDetailPi = new CurrencySaleDetailPi()
                {
                    CurrencySaleId = currencySalesId,
                    Price = price,
                    ProfitLossAmount = profit,
                    PeroformaInvoiceDetailId = piDetailDto.Id
                };
                await _salePiDetailRepository.AddEntity(currencySaleDetailPi);
                await _salePiDetailRepository.SaveChanges();

                #endregion

                #region Update Sold In PiDetail

                if (price + usedPriceOfExdecCode == piDetailDto.DepositPrice)
                {
                    var updateSold = await _piDetailRepository.SoldedPiDetail(piDetailDto.Id);
                    if (!updateSold)
                        return SalesResult.CanNotUpdateSoldPiDetailInDataBase;
                }

                var updateBrokerAmount = await _brokerRepository.UpdateBrokerAmount(saleDto.BrokerId,price,false);
                if (!updateBrokerAmount)
                    return SalesResult.CannotUpdateBrokerAmountBalance;
                #endregion

                totalInserted += price;
                if (totalInserted == saleDto.SalePrice)
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
            var sumExDec = await _declarationRepository.GetSumExDecAccountBalance();
            if (createPiDto.SalePrice > sumExDec)
            {
                return SalesResult.ExDecAccountBalanceIsLowerThanPrice;
            }

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
        }

        #endregion

    }
}