using System.Collections.Generic;
using CurrencyExchange.Core.Dtos.Paging;

namespace CurrencyExchange.Application.Dtos.Paging
{
    public class FilterGenericDto<TEntity> : BasePaging , IFilterListItems<TEntity>
    {

        #region Properties

        public string SearchText { get; set; }
        public List<TEntity> Entities { get; set; }

        #endregion

        #region Methods

        public FilterGenericDto<TEntity> SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.PageCount = paging.PageCount;
            this.ActivePage = paging.ActivePage;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            return this;

        }

        public FilterGenericDto<TEntity> SetEntitiesDto(List<TEntity> entities)
        {
            this.Entities = entities;
            return this;

        }

        #endregion


    }
}
