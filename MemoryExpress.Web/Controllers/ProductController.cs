using AutoMapper;
using MemoryExpress.Core.Domain.Catalog;
using MemoryExpress.Core.Services.Catalog;
using MemoryExpress.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemoryExpress.Web.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private ApplicationUserManager _userManager;
        private IProductService _productService;
        private IMapper _mapper;

        #endregion

        #region Constructor

        public ProductController(ApplicationUserManager userManager, IProductService productService, IMapper mapper)
        {
            UserManager = userManager;
            _productService = productService;
            _mapper = mapper;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        #endregion

        #region Methods

        // GET: Product
        public ActionResult Index(string seo)
        {
            if (seo != null)
            {
                var productEntity = _productService.GetProductBySeo(seo);

                if (productEntity != null)
                {
                    var productModel = _mapper.Map<Product, ProductModel>(productEntity);

                    // decode description to html
                    productModel.Description = System.Net.WebUtility.HtmlDecode(productModel.Description);

                    // get all images
                    if (productEntity.Images.Count() > 0)
                    {
                        productModel.MainImage = productEntity.Images
                            .OrderBy(x => x.SortOrder)
                            .FirstOrDefault()
                            .Image
                            .FileName;

                        productModel.ProductImages = productEntity.Images.Select(x => x.Image.FileName).ToList();
                    }

                    // check for deal
                    if (productEntity.Deals.Count() > 0)
                    {
                        productModel.Deals = new List<DealModel>();

                        foreach (var dealEntity in productEntity.Deals.Select(x => x.Deal))
                        {
                            productModel.Deals.Add(_mapper.Map<Deal, DealModel>(dealEntity));
                        }

                        productModel.DealPrice = productEntity.Deals
                            .Where(x => x.Deal.DealType == DealTypes.Single)
                            .FirstOrDefault()
                            .Price;
                    }

                    // get all manufacturers
                    if (productEntity.Manufacturers.Count() > 0)
                    {
                        productModel.Manufacturers = new List<ManufacturerModel>();

                        foreach (var manufacturerEntity in productEntity.Manufacturers.Select(x => x.Manufacturer))
                        {
                            productModel.Manufacturers.Add(_mapper.Map<Manufacturer, ManufacturerModel>(manufacturerEntity));
                        }
                    }

                    // get all specifications
                    if (productEntity.Specifications.Count() > 0)
                    {
                        productModel.Specifications = new List<SpecificationModel>();

                        foreach (var specificationMappingEntity in productEntity.Specifications.OrderBy(x => x.SortOrder))
                        {
                            var specificationModel = _mapper.Map<Specification, SpecificationModel>(specificationMappingEntity.Specification);

                            specificationModel.SortOrder = specificationMappingEntity.SortOrder;
                            specificationModel.Value = specificationMappingEntity.Value;

                            productModel.Specifications.Add(specificationModel);
                        }
                    }

                    // get product rating

                    ViewData["ProductId"] = productModel.Id;

                    return View(productModel);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}