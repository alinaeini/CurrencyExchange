using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Dtos.Pi;
using CurrencyExchange.Core.Sequrity;
using CurrencyExchange.Core.Utilities.Extensions;
using CurrencyExchange.Domain.EntityModels.PeroformaInvoices;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class PiService : IPiService
    {
        #region Costructor

        private IPiRepository piRepository;
        private IPiDetailService piDetailService;

        public PiService(IPiRepository piRepository, IPiDetailService detailService)
        {
            this.piRepository = piRepository;
            piDetailService = detailService;
        }

        #endregion

        #region Pi Section

        #region Create

        public async Task<PiResult> Create(CreatePiDto createPiDto)
        {
            var isExist = piRepository.IsPiExistByCode(createPiDto.PiCode.Trim().ToLower());
            if (isExist)
                return PiResult.ProformaInvoiceIsExist;
            var pi = new PeroformaInvoice()
            {
                BasePrice = createPiDto.BasePrice,
                PiCode = createPiDto.PiCode.SanitizeText(),
                PiDate = createPiDto.PiDate,
                TotalPrice = createPiDto.TotalPrice,
                IsSold = false
            };
            await piRepository.AddEntity(pi);
            await piRepository.SaveChanges();
            return PiResult.Success;
        }

        #endregion

        #region Filter By PiCode , 

        public async Task<FilterPiDto> GetPiesByFiltersList(FilterPiDto filterPiDto)
        {
            var asQueryable = piRepository
                .GetEntities()
                .Where(x => !x.IsSold)
                .AsQueryable();

            if (filterPiDto.SearchText != null || !(string.IsNullOrWhiteSpace(filterPiDto.SearchText)))
            {
                asQueryable = asQueryable.Where(x => x.PiCode.Contains(filterPiDto.SearchText.Trim()));
            }

            var count = (int)Math.Ceiling(asQueryable.Count() / (double)filterPiDto.TakeEntity);
            var pager = Pager.Builder(count, filterPiDto.PageId, filterPiDto.TakeEntity);
            var peroformaInvoices = await asQueryable.Paging(pager).ToListAsync();
            filterPiDto.PiRemaind = new List<PiRemaindDto>();
            foreach (var item in peroformaInvoices)
            {
                var payDetails = await piDetailService.GetTotalAamountReceivedFromTheCustomer(item.Id);
                //if (PayDetails < item.TotalPrice)
                //{
                filterPiDto.PiRemaind.Add(new PiRemaindDto()
                    {
                        BasePrice = item.BasePrice,
                        PiCode = item.PiCode,
                        TotalPrice = item.TotalPrice,
                        PiDate = item.PiDate,
                        RemaindPrice = item.TotalPrice - payDetails,
                        SoldPrice = payDetails,
                        Id = item.Id
                    });
                //}

            }

            return filterPiDto.SetPies(filterPiDto.PiRemaind).SetPaging(pager);
        }
        #endregion

        #region Get Pi By ID

        public async Task<PiDto> GetPiById(long id)
        {
            var pi = await piRepository.GetEntityById(id);
            if (pi == null)
            {
                return null;
            }
            return new PiDto()
            {
                Id = pi.Id,
                PiCode = pi.PiCode.Trim().SanitizeText(),
                PiDate = pi.PiDate,
                BasePrice = pi.BasePrice,
                TotalPrice = pi.TotalPrice
                
        };
        }
        #endregion

        #region Edit

        public async Task<PiResult> EditPiInfo(PiDto piDto)
        {
            var pi = await piRepository.GetEntityById(piDto.Id);
            if (pi == null)
                return PiResult.CanNotUpdate;

            pi.PiCode = piDto.PiCode.Trim().SanitizeText();
            pi.PiDate = piDto.PiDate;
            pi.IsSold = false;
            pi.BasePrice = piDto.BasePrice;
            pi.TotalPrice = piDto.TotalPrice;
            piRepository.UpdateEntity(pi);
            await piRepository.SaveChanges();
            return PiResult.Success;
        }

        #endregion

        #region Delete

        public async Task<PiResult> DeletePiInfo(long id)
        {
            await piRepository.RemoveEntity(id);
            await piRepository.SaveChanges();
            return PiResult.Success;
        }

        #endregion

        #endregion

        #region Dispose

        public void Dispose()
        {
            this.piRepository?.Dispose();
            this.piDetailService?.Dispose();
        }


        #endregion
    }
}
