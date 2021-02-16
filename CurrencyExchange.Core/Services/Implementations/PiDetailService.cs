using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Dtos.Pi.PiDetail;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Extensions;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class PiDetailService : IPiDetailService
    {
        #region Costructor

        private IPiDetailRepository piDetailRepository;
        private IBrokerRepository _brokerRepository;


        public PiDetailService(IPiDetailRepository piDetailRepository, IBrokerRepository brokerRepository)
        {
            this.piDetailRepository = piDetailRepository;
            _brokerRepository = brokerRepository;
        }

        #endregion

        #region Pi Details Section

        #region Create

        public async Task<PiDetailResult> Create(CreatePiDetailDto createPiDetailDto)
        {
            var piDetail = new PeroformaInvoiceDetail()
            {
                DepositDate = createPiDetailDto.DepositDate,
                DepositPrice = createPiDetailDto.DepositPrice,
                BrokerId = createPiDetailDto.BrokerId,
                PeroformaInvoiceId = createPiDetailDto.PiId,
                IsSold = false
            };
            await piDetailRepository.AddEntity(piDetail);

            await _brokerRepository.UpdateBrokerAmount(piDetail.BrokerId, piDetail.DepositPrice, true);
            await piDetailRepository.SaveChanges();
            return PiDetailResult.Success;

        }

        #endregion

        #region Filter any things

        public async Task<FilterPiDetailDto> GetPiesByFiltersList(FilterPiDetailDto filterPiDetailDto)
        {
            var asQueryable = piDetailRepository
                                            .GetEntities()
                                            .Where(x => x.PeroformaInvoiceId == filterPiDetailDto.PiId)
                                            .AsQueryable();
            //if (filterPiDetailDto.SearchText != null || !(string.IsNullOrWhiteSpace(filterPiDetailDto.SearchText)))
            //{
            //    asQueryable = asQueryable.Where(x => x.PiCode.Contains(filterPiDto.SearchText.Trim()));
            //}
            var count = (int)Math.Ceiling(asQueryable.Count() / (double)filterPiDetailDto.TakeEntity);
            var pager = Pager.Builder(count, filterPiDetailDto.PageId, filterPiDetailDto.TakeEntity);
            var list = await asQueryable.Paging(pager).ToListAsync();
            filterPiDetailDto.PiDetailDtos = new List<PiDetailDto>();
            foreach (var item in list)
            {
                filterPiDetailDto.PiDetailDtos.Add(new PiDetailDto()
                {
                    BrokerId = item.BrokerId,
                    PiId = item.PeroformaInvoiceId,
                    DepositDate = item.DepositDate,
                    DepositPrice = item.DepositPrice,
                    Id = item.Id,
                    IsSold = item.IsSold
                });
            }
            return filterPiDetailDto.SetPiDetails(filterPiDetailDto.PiDetailDtos).SetPaging(pager);
        }

        #endregion

        #region Get Pi Detail By ID

        public async Task<PiDetailDto> GetPiDetailById(long id)
        {
            var piDetail = await piDetailRepository.GetEntityById(id);
            if (piDetail == null)
            {
                return null;
            }

            return new PiDetailDto()
            {
                Id = piDetail.Id,
                DepositPrice = piDetail.DepositPrice,
                DepositDate = piDetail.DepositDate,
                BrokerId = piDetail.BrokerId,
                PiId = piDetail.PeroformaInvoiceId,
                IsSold = piDetail.IsSold
            };
        }

        #endregion

        #region Edit

        public async Task<PiDetailResult> EditPiInfo(PiDetailDto piDetailDto)
        {
            var piDetail = await piDetailRepository.GetEntityById(piDetailDto.Id);
            if (piDetail == null)
                return PiDetailResult.CanNotUpdate;

            #region Update Broker Balance

            if (piDetail.DepositPrice > piDetailDto.DepositPrice)
            {
                var updateBrokerAmount = await _brokerRepository.UpdateBrokerAmount(piDetail.BrokerId, piDetail.DepositPrice - piDetailDto.DepositPrice, false);
                if (!updateBrokerAmount)
                    return PiDetailResult.CannotUpdateBrokerAmountBalance;
            }
            else
            {
                var updateBrokerAmount = await _brokerRepository.UpdateBrokerAmount(piDetail.BrokerId,  piDetailDto.DepositPrice - piDetail.DepositPrice , true);
                if (!updateBrokerAmount)
                    return PiDetailResult.CannotUpdateBrokerAmountBalance;
            }

            #endregion

            piDetail.DepositPrice = piDetailDto.DepositPrice;
            piDetail.DepositDate = piDetailDto.DepositDate;
            piDetail.BrokerId = piDetailDto.BrokerId;
            piDetail.PeroformaInvoiceId = piDetailDto.PiId;
            piDetail.IsSold = false;
            piDetailRepository.UpdateEntity(piDetail);
            await piDetailRepository.SaveChanges();

            return PiDetailResult.Success;
        }


        #endregion

        #region Delete

        public async Task<PiDetailResult> DeletePiDetailInfo(long id)
        {
            await piDetailRepository.RemoveEntity(id);
            await piDetailRepository.SaveChanges();
            return PiDetailResult.Success;
        }



        #endregion

        #region GetTotalAamountReceivedFromTheCustomer





        public async Task<long> GetTotalAamountReceivedFromTheCustomer(long id)
        {
            return await piDetailRepository.SumPayDetails(id);
        }

        #endregion



        #endregion

        #region Dispose

        public void Dispose()
        {
            this.piDetailRepository?.Dispose();
            this._brokerRepository?.Dispose();
        }

        #endregion
    }
}