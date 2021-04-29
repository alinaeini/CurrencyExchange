using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Broker;
using CurrencyExchange.Core.Dtos.Paging;
using CurrencyExchange.Core.Sequrity;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Extensions;
using CurrencyExchange.Domain.EntityModels.Broker;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Application.Services.Implementations
{
    public class BrokerService:IBrokerService
    {
        #region Costructor

        private readonly IBrokerRepository brokerRepository;
        private readonly IPiDetailRepository piDetailRepository;


        public BrokerService(IBrokerRepository brokerRepository, IPiDetailRepository piDetailRepository)
        {
            this.brokerRepository = brokerRepository;
            this.piDetailRepository = piDetailRepository;
        }

        #endregion
        
        #region Broker Methods

        #region Create

        public async Task<BrokerResult> Create(CreateBrokerDto brokerDto)
        {
            var IsExist = brokerRepository.IsBrokerExistByName(brokerDto.Name.Trim().ToLower());
            if (IsExist)
                return BrokerResult.BrokerIsExist;
            var broker = new Broker()
            {
                Title = brokerDto.Title.SanitizeText(),
                Address = brokerDto.Address.SanitizeText(),
                Description = brokerDto.Description.SanitizeText(),  
                Name = brokerDto.Name.SanitizeText(),
                Tel = brokerDto.Tel.SanitizeText(),
                ServiceChargeAccount = brokerDto.ServiceChargeAccount,
                ServiceChargeCash = brokerDto.ServiceChargeCash,
                AmountBalanceBroker = 0
            };
            await brokerRepository.AddEntity(broker);
            await brokerRepository.SaveChanges();
            return BrokerResult.Success;
        }

        #endregion

        #region Filter By Name

        public async Task<FilterBrokerDto> GetBrokersByFiltersList(FilterBrokerDto filterBrokerDto)
        {
            var cuastomerList = brokerRepository.GetEntities().AsQueryable();

            if (filterBrokerDto.SearchText != null || !(string.IsNullOrEmpty(filterBrokerDto.SearchText)))
            {
                cuastomerList = cuastomerList.Where(x => x.Title.Contains(filterBrokerDto.SearchText.Trim()) ||
                                                         x.Name.Contains(filterBrokerDto.SearchText.Trim()));
            }

            var count = (int)Math.Ceiling(cuastomerList.Count() / (double)filterBrokerDto.TakeEntity);
            var pager = Pager.Builder(count, filterBrokerDto.PageId, filterBrokerDto.TakeEntity);
            var brokers = await cuastomerList.Paging(pager).ToListAsync();
            filterBrokerDto.BrokerDtos = new List<BrokerDto>();
            foreach (var item in brokers)
            {
                filterBrokerDto.BrokerDtos.Add(new BrokerDto
                {
                    Title = item.Title,
                    Name = item.Name,
                    Tel = item.Tel,
                    Address = item.Address,
                    Description = item.Description,
                    ServiceChargeAccount = item.ServiceChargeAccount,
                    ServiceChargeCash = item.ServiceChargeCash,
                    Id = item.Id
                });
            }

            return filterBrokerDto.SetBroker(filterBrokerDto.BrokerDtos).SetPaging(pager);
        }

        #endregion

        #region Get broker By ID

        public async Task<BrokerDto> GetBrokerById(long id)
        {
            var broker = await brokerRepository.GetEntityById(id);
            if (broker == null)
            {
                return null;
            }
            return new BrokerDto
            {
                Id = broker.Id,
                Name = broker.Name.Trim().SanitizeText(),
                Tel = broker.Tel.Trim().SanitizeText(),
                Address = broker.Address.Trim().SanitizeText(),
                Description = broker.Description.Trim().SanitizeText(),
                ServiceChargeAccount = broker.ServiceChargeAccount,
                ServiceChargeCash = broker.ServiceChargeCash,
                Title = broker.Title
            };
        }

        #endregion

        #region Get brokers

        public async Task<List<BrokerDto>> GetBrokers()
        {
            var brokersDto = new List<BrokerDto>();
            var brokers = await brokerRepository.GetEntities().ToListAsync();
            if (brokers != null)
            {
                foreach (var broker in brokers)
                {
                    brokersDto.Add(new BrokerDto
                    {
                        Id = broker.Id,
                        Name = broker.Name.Trim().SanitizeText(),
                        Tel = broker.Tel.Trim().SanitizeText(),
                        Address = broker.Address.Trim().SanitizeText(),
                        Description = broker.Description.Trim().SanitizeText(),
                        ServiceChargeAccount = broker.ServiceChargeAccount,
                        ServiceChargeCash = broker.ServiceChargeCash,
                        Title = broker.Title,
                        AccountBalance = broker.AmountBalanceBroker??0
                    });
                }
            }
            return brokersDto;
        }

        #endregion

        #region Edit

        public async Task<BrokerResult> EditBrokerInfo(BrokerDto brokerDto)
        {
            var broker = await brokerRepository.GetEntityById(brokerDto.Id);
            if (broker == null)
                return BrokerResult.CanNotUpdate;
            broker.Address = brokerDto.Address.SanitizeText().Trim();
            broker.Description = brokerDto.Description.SanitizeText().Trim();
            broker.Name = brokerDto.Name.SanitizeText().Trim();
            broker.Tel = brokerDto.Tel.SanitizeText().Trim();
            broker.Title = brokerDto.Title.SanitizeText().Trim();
            broker.ServiceChargeAccount = brokerDto.ServiceChargeAccount;
            broker.ServiceChargeCash = brokerDto.ServiceChargeCash;
            brokerRepository.UpdateEntity(broker);
            await brokerRepository.SaveChanges();
            return BrokerResult.Success;
        }

        #endregion

        #region Delete

        public async Task<BrokerResult> DeleteBrokerInfo(long Id)
        {
            await brokerRepository.RemoveEntity(Id);
            await brokerRepository.SaveChanges();
            return BrokerResult.Success;
        }

        #endregion

        #endregion

        #region Dispose

        public void Dispose()
        {
            this.brokerRepository?.Dispose();
        }



        #endregion
    }
}
