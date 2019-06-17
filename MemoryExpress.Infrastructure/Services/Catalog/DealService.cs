using MemoryExpress.Core.Domain.Catalog;
using MemoryExpress.Core.Services.Catalog;
using MemoryExpress.Infrastructure.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryExpress.Infrastructure.Services.Catalog
{
    public class DealService : IDealService
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private readonly IRepository<Deal> _dealRepository;
        private readonly IRepository<ProductDealMapping> _productDealRepository;

        #endregion

        #region Constructor

        public DealService(ApplicationDbContext context, IRepository<Deal> dealRepository, IRepository<ProductDealMapping> productDealRepository)
        {
            _context = context;
            _dealRepository = dealRepository;
            _productDealRepository = productDealRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all deals
        /// </summary>
        /// <returns>List of deal entities</returns>
        public IList<Deal> GetAllDeals()
        {
            var entities = _dealRepository.GetAll()
                .OrderBy(x => x.Name)
                .ToList();

            return entities;
        }

        /// <summary>
        /// Get deal using id
        /// </summary>
        /// <param name="id">Deal id</param>
        /// <returns>Deal entity</returns>
        public Deal GetDealById(int id)
        {
            return _dealRepository.FindByExpression(x => x.Id == id);
        }

        /// <summary>
        /// Insert deal
        /// </summary>
        /// <param name="deal">Deal entity</param>
        public void InsertDeal(Deal deal)
        {
            if (deal == null)
                throw new ArgumentNullException("deal");

            _dealRepository.Insert(deal);
            _dealRepository.SaveChanges();
        }

        /// <summary>
        /// Update deal 
        /// </summary>
        /// <param name="deal">Deal entity</param>
        public void UpdateDeal(Deal deal)
        {
            if (deal == null)
                throw new ArgumentNullException("deal");

            _dealRepository.Update(deal);
            _dealRepository.SaveChanges();
        }

        /// <summary>
        /// Delete categories
        /// </summary>
        /// <param name="ids">Ids of categories to delete</param>
        public void DeleteDeals(IList<int> ids)
        {
            if (ids == null)
                throw new ArgumentNullException("ids");

            foreach (var id in ids)
                _dealRepository.Delete(GetDealById(id));

            _dealRepository.SaveChanges();
        }

        /// <summary>
        /// Insert product deal mappings
        /// </summary>
        /// <param name="productDealMappings">List of product deal mapping</param>
        public void InsertProductDealMappings(IList<ProductDealMapping> productDealMappings)
        {
            if (productDealMappings == null)
                throw new ArgumentNullException("productDealMappings");

            foreach (var mapping in productDealMappings)
                _productDealRepository.Insert(mapping);

            _productDealRepository.SaveChanges();
        }

        /// <summary>
        /// Delete all product deal mappings using product id
        /// </summary>
        /// <param name="productId">Product id</param>
        public void DeleteAllProductDealMappingsByProductId(int productId)
        {
            var mappings = _productDealRepository.FindManyByExpression(x => x.ProductId == productId);

            foreach (var mapping in mappings)
                _productDealRepository.Delete(mapping);

            _productDealRepository.SaveChanges();
        }

        #endregion
    }
}