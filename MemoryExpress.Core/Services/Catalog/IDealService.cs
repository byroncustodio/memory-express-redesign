using MemoryExpress.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryExpress.Core.Services.Catalog
{
    public interface IDealService
    {
        /// <summary>
        /// Get all deals
        /// </summary>
        /// <returns>List of deal entities</returns>
        IList<Deal> GetAllDeals();

        /// <summary>
        /// Get deal using id
        /// </summary>
        /// <param name="id">Deal id</param>
        /// <returns>Deal entity</returns>
        Deal GetDealById(int id);

        /// <summary>
        /// Insert deal
        /// </summary>
        /// <param name="deal">Deal entity</param>
        void InsertDeal(Deal deal);

        /// <summary>
        /// Update deal 
        /// </summary>
        /// <param name="category">Deal entity</param>
        void UpdateDeal(Deal deal);

        /// <summary>
        /// Delete deals
        /// </summary>
        /// <param name="ids">Ids of deals to delete</param>
        void DeleteDeals(IList<int> ids);

        /// <summary>
        /// Insert product deal mappings
        /// </summary>
        /// <param name="productDealMappings">List of product deal mapping</param>
        void InsertProductDealMappings(IList<ProductDealMapping> productDealMappings);

        /// <summary>
        /// Delete all product deal mappings using product id
        /// </summary>
        /// <param name="productId">Product id</param>
        void DeleteAllProductDealMappingsByProductId(int productId);
    }
}
