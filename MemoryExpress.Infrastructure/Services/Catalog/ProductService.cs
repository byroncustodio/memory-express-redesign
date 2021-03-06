﻿using MemoryExpress.Core.Domain.Catalog;
using MemoryExpress.Core.Services.Catalog;
using MemoryExpress.Infrastructure.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace MemoryExpress.Infrastructure.Services.Catalog
{
    public class ProductService : IProductService
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private readonly IRepository<Product> _productRepository;

        #endregion

        #region Constructor

        public ProductService(ApplicationDbContext context, IRepository<Product> productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of product entities</returns>
        public IList<Product> GetAllProducts()
        {
            // TODO: update when lazy loading is available
            var entities = _context.Products
                .Include(x => x.Categories.Select(y => y.Category))
                .Include(x => x.Deals.Select(y => y.Deal))
                .Include(x => x.Images.Select(y => y.Image))
                .Include(x => x.Manufacturers.Select(y => y.Manufacturer))
                .Include(x => x.Specifications.Select(y => y.Specification))
                .AsNoTracking()
                .ToList();

            return entities;
        }

        /// <summary>
        /// Get product usind id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Product entity</returns>
        public Product GetProductById(int id)
        {
            // TODO: update when lazy loading is available
            var entity = _context.Products
                .Include(x => x.Categories.Select(y => y.Category))
                .Include(x => x.Images.Select(y => y.Image))
                .Include(x => x.Deals.Select(y => y.Deal))
                .Include(x => x.Manufacturers.Select(y => y.Manufacturer))
                .Include(x => x.Specifications.Select(y => y.Specification))
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);

            return entity;
        }

        /// <summary>
        /// Get product using seo
        /// </summary>
        /// <param name="seo">Product SEO</param>
        /// <returns>Product entity</returns>
        public Product GetProductBySeo(string seo)
        {
            if (seo == "")
                return null;

            // TODO: update when lazy loading is available
            var entity = _context.Products
                .Include(x => x.Categories.Select(y => y.Category))
                .Include(x => x.Deals.Select(y => y.Deal))
                .Include(x => x.Images.Select(y => y.Image))
                .Include(x => x.Manufacturers.Select(y => y.Manufacturer))
                .Include(x => x.Specifications.Select(y => y.Specification))
                .AsNoTracking()
                .SingleOrDefault(x => x.SeoUrl == seo);

            return entity;
        }

        /// <summary>
        /// Insert product
        /// </summary>
        /// <param name="product">Product entity</param>
        public void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            _productRepository.Insert(product);
            _productRepository.SaveChanges();
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product">Product entity</param>
        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }

        /// <summary>
        /// Delete products
        /// </summary>
        /// <param name="ids">Ids of product to delete</param>
        public void DeleteProducts(IList<int> ids)
        {
            if (ids == null)
                throw new ArgumentNullException("ids");

            foreach (var id in ids)
                _productRepository.Delete(GetProductById(id));

            _productRepository.SaveChanges();
        }

        /// <summary>
        /// Search products
        /// </summary>
        /// <param name="nameFilter">Name filter</param>
        /// <param name="seoFilter">SEO filter</param>
        /// <param name="categoryFilter">Category filter</param>
        /// <param name="manufacturerFilter">Manufacturer filter</param>
        /// <param name="priceFilter">Price filter</param>
        /// <param name="isPublished">Published filter</param>
        /// <returns>List of product entities</returns>
        public IList<Product> SearchProduct(string nameFilter = null, string seoFilter = null, string[] categoryFilter = null, string[] dealFilter = null, string[] manufacturerFilter = null, string[] priceFilter = null, bool isPublished = true)
        {
            var result = _context.Products
                .Include(x => x.Categories.Select(y => y.Category))
                .Include(x => x.Deals.Select(y => y.Deal))
                .Include(x => x.Images.Select(y => y.Image))
                .Include(x => x.Manufacturers.Select(y => y.Manufacturer))
                .Include(x => x.Specifications.Select(y => y.Specification))
                .AsNoTracking();

            // published filter
            if (isPublished == false)
            {
                result = result.Where(x => x.Published == false);
            }

            // name filter
            if (nameFilter != null && nameFilter.Length > 0)
            {
                result = result.Where(x => x.Name.ToLower().Contains(nameFilter.ToLower()));
            }

            // seo filter
            if (seoFilter != null && seoFilter.Length > 0)
            {
                throw new NotImplementedException();
            }

            // category filter
            if (categoryFilter != null && categoryFilter.Length > 0)
            {
                result = result.Where(x => x
                    .Categories.Select(c => c.Category.Name.ToLower())
                    .Intersect(categoryFilter.Select(cf => cf.ToLower()))
                    .Count() > 0
                );
            }

            // deal filter
            if (dealFilter != null && dealFilter.Length > 0)
            {
                result = result.Where(x => x
                    .Deals.Select(d => d.Deal.Name.ToLower())
                    .Intersect(dealFilter.Select(df => df.ToLower()))
                    .Count() > 0
                );
            }

            // manufacturer filter
            if (manufacturerFilter != null && manufacturerFilter.Length > 0)
            {
                result = result.Where(x => x
                    .Manufacturers
                    .Select(c => c.Manufacturer.Name.ToLower())
                    .Intersect(manufacturerFilter.Select(mf => mf.ToLower()))
                    .Count() > 0
                );
            }

            // price filter
            if (priceFilter != null && priceFilter.Length > 0)
            {
                var tmpResult = new List<Product>();
                foreach (var price in priceFilter)
                {
                    var p = price.Split('-');
                    int minPrice = Int32.Parse(p[0]);
                    int maxPrice = Int32.Parse(p[1]);

                    var r = result.Where(x => x.Price >= minPrice && x.Price <= maxPrice);
                    if (r.Count() > 0) tmpResult.AddRange(r);
                }
                result = tmpResult.AsQueryable();
            }

            return result.ToList();
        }

        /// <summary>
        /// Get product context table
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> Table()
        {
            return _context.Products;
        }

        #endregion
    }
}