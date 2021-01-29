using System;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Domain.RepositoryInterfaces;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.ExDecalaration;
using CurrencyExchange.Core.Sequrity;
using CurrencyExchange.Domain.EntityModels.ExchangeDeclaration;
using System.Collections.Generic;
using System.Linq;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class ExDeclarationService : IExDeclarationService
    {
        #region Constructor

        private readonly IExDeclarationRepository _exDeclarationRepository;
        private readonly ICurrencySaleExDecRepository _saleDetailRepository;

        public ExDeclarationService(IExDeclarationRepository exDeclarationRepository, ICurrencySaleExDecRepository saleDetailRepository)
        {
            _exDeclarationRepository = exDeclarationRepository;
            _saleDetailRepository = saleDetailRepository;
        }

        #endregion

        #region ExDeclarationService Methods
        
        #region Create

        public async Task<ExDeclarationResult> CreateExDec(CreateExDecDto exDeclaration)
        {
            var isExCodeExist = _exDeclarationRepository.IsCodeExist(exDeclaration.ExCode.Trim().ToLower());
            if (isExCodeExist)
                return ExDeclarationResult.ExDecIsExist;
            var exDec = new ExDeclaration
            {
                ExchangeDeclarationCode = exDeclaration.ExCode.Trim().SanitizeText(),
                ExprireDate = exDeclaration.ExpireDate,
                IsSold = false,
                Price = exDeclaration.Price,
                Qty = exDeclaration.Qty
            };
            await _exDeclarationRepository.AddEntity(exDec);
            await _exDeclarationRepository.SaveChanges();
            return ExDeclarationResult.Success;
        }

        #endregion

        #region Filter - ExCode

        #region Filtered - Is Not Sold

        public async Task<FilterExDecDto> GetExDecsByFiltersList(FilterExDecDto filterExDecDto)
        {
            var asQueryable = _exDeclarationRepository
                .GetEntities()
                .Where(x => !x.IsSold)
                .AsQueryable();

            if (filterExDecDto.SearchText != null || !(string.IsNullOrWhiteSpace(filterExDecDto.SearchText)))
            {
                asQueryable = asQueryable.Where(x => x.ExchangeDeclarationCode.Contains(filterExDecDto.SearchText.Trim()));
            }

            var count = (int)Math.Ceiling(asQueryable.Count() / (double)filterExDecDto.TakeEntity);
            var pager = Pager.Builder(count, filterExDecDto.PageId, filterExDecDto.TakeEntity);
            var exdecs = await asQueryable.Paging(pager).ToListAsync();
            filterExDecDto.ExDecRemaind = new List<ExDecRemaindDto>();
            foreach (var item in exdecs)
            {
                var soldExCode = await _saleDetailRepository.GetSumExCodeUsedById(item.Id);
                filterExDecDto.ExDecRemaind.Add(new ExDecRemaindDto()
                {
                    ExCode = item.ExchangeDeclarationCode,
                    ExpireDate = item.ExprireDate,
                    Price = item.Price,
                    Qty = item.Qty,
                    SoldPrice = soldExCode ,
                    RemaindPrice = item.Price - soldExCode,
                    Id = item.Id
                });
            }

            return filterExDecDto.SetExDec(filterExDecDto.ExDecRemaind).SetPaging(pager);
        }

        #endregion

        #region All ExDecs With SumSold in ExDecId

        public async Task<FilterExDecDto> GetExDecsByFilterSoldAndExdecList(FilterExDecDto filterExDecDto)
        {
            var asQueryable = _exDeclarationRepository
                .GetEntities()
                .AsQueryable();
            if (filterExDecDto.SearchText != null || !(string.IsNullOrWhiteSpace(filterExDecDto.SearchText)))
            {
                asQueryable = asQueryable.Where(x => x.ExchangeDeclarationCode.Contains(filterExDecDto.SearchText.Trim()));
            }

            var count = (int)Math.Ceiling(asQueryable.Count() / (double)filterExDecDto.TakeEntity);
            var pager = Pager.Builder(count, filterExDecDto.PageId, filterExDecDto.TakeEntity);
            var exdecs = await asQueryable.Paging(pager).ToListAsync();
            filterExDecDto.ExDecRemaind = new List<ExDecRemaindDto>();
            foreach (var item in exdecs)
            {
                var soldExCode = await _saleDetailRepository.GetSumExCodeUsedById(item.Id);
                filterExDecDto.ExDecRemaind.Add(new ExDecRemaindDto()
                {
                    ExCode = item.ExchangeDeclarationCode,
                    ExpireDate = item.ExprireDate,
                    Price = item.Price,
                    Qty = item.Qty,
                    SoldPrice = soldExCode,
                    RemaindPrice = item.Price - soldExCode,
                    Id = item.Id
                });
            }

            return filterExDecDto.SetExDec(filterExDecDto.ExDecRemaind).SetPaging(pager);
        }

        #endregion

        #endregion

        #region Get ExDec By ID

        public async Task<ExDecDto> GetExDecById(long id)
        {
            var exDeclaration = await _exDeclarationRepository.GetEntityById(id);
            if (exDeclaration == null)
            {
                return null;
            }
            return new ExDecDto()
            {
                Id = exDeclaration.Id,
                ExCode = exDeclaration.ExchangeDeclarationCode,
                ExpireDate = exDeclaration.ExprireDate,
                Price = exDeclaration.Price,
                Qty = exDeclaration.Qty
            };
        }

        #region  Get ExDecs List

        public async Task<List<ExDecRemaindDto>> GetExDecs()
        {
            var exDecDto = new List<ExDecRemaindDto>();
            var exDeclarations = await _exDeclarationRepository
                                                .GetEntities()
                                                .Where(x=>!x.IsSold)
                                                .ToListAsync();
            
            if (exDeclarations != null)
            {
                foreach (var exDeclaration in exDeclarations)
                {
                    var soldExCode = await _saleDetailRepository.GetSumExCodeUsedById(exDeclaration.Id);
                    exDecDto.Add(new ExDecRemaindDto
                    {
                        Id = exDeclaration.Id,
                        ExCode = exDeclaration.ExchangeDeclarationCode,
                        ExpireDate = exDeclaration.ExprireDate,
                        SoldPrice = soldExCode ,
                        RemaindPrice = exDeclaration.Price - soldExCode ,
                        Price = exDeclaration.Price,
                        Qty = exDeclaration.Qty
                    });
                }
            }
            return exDecDto;
        }

        #endregion



        #endregion

        #region Edit

        public async Task<ExDeclarationResult> EditExDecInfo(ExDecDto exDecDto)
        {
            var exDeclaration = await _exDeclarationRepository.GetEntityById(exDecDto.Id);
            if (exDeclaration == null)
                return ExDeclarationResult.ExDecCanNotUpdate;

            exDeclaration.ExchangeDeclarationCode = exDecDto.ExCode.Trim().SanitizeText();
            exDeclaration.ExprireDate = exDecDto.ExpireDate;
            exDeclaration.IsSold = false;
            exDeclaration.Price = exDecDto.Price;
            exDeclaration.Qty = exDecDto.Qty;
            _exDeclarationRepository.UpdateEntity(exDeclaration);
            await _exDeclarationRepository.SaveChanges();
            return ExDeclarationResult.Success;
        }

        #endregion

        #region Delete

        public async Task<ExDeclarationResult> DeleteExDecInfo(long id)
        {
            await _exDeclarationRepository.RemoveEntity(id);
            await _exDeclarationRepository.SaveChanges();
            return ExDeclarationResult.Success;
        }

        #endregion


        #endregion

        #region Dispose

        public void Dispose()
        {
            _exDeclarationRepository?.Dispose();
            _saleDetailRepository?.Dispose();
        }



        #endregion
    }
}