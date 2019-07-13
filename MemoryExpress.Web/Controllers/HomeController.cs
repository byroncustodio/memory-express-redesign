using AutoMapper;
using MemoryExpress.Core.Domain.Catalog;
using MemoryExpress.Core.Services.Catalog;
using MemoryExpress.Web.Models;
using MemoryExpress.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemoryExpress.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private ApplicationUserManager _userManager;
        private IProductService _productService;
        private IMapper _mapper;

        #endregion

        #region Constructor

        public HomeController(ApplicationUserManager userManager, IProductService productService, IMapper mapper)
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

        public ActionResult Index()
        {
            var currentDeals = new List<string> { "Featured Deals", "Laptops & PC Deals", "Component Deals" };
            var productDeals = currentDeals
                .Select(x => new HomeProductDealViewModel { DealName = x, Products = new List<ProductModel>() })
                .ToList();
            var productEntities = _productService.SearchProduct(dealFilter: currentDeals.ToArray());

            foreach (var productEntity in productEntities)
            {
                var productModel = _mapper.Map<Product, ProductModel>(productEntity);

                // get main image
                if (productEntity.Images.Count() > 0)
                {
                    productModel.MainImage = productEntity.Images
                        .OrderBy(x => x.SortOrder)
                        .FirstOrDefault()
                        .Image
                        .FileName;
                }

                // check for deal
                if (productEntity.Deals.Count() > 0)
                {
                    productModel.Deals = new List<DealModel>();

                    var dealsList = productEntity.Deals.Select(x => x.Deal);

                    for (int i = 0; i < dealsList.Count(); i++)
                    {
                        var deal = dealsList.ElementAt(i);

                        productModel.Deals.Add(_mapper.Map<Deal, DealModel>(deal));

                        // add product to user-defined deals listed above
                        foreach (var productDeal in productDeals)
                        {
                            if (productDeal.DealName == deal.Name)
                            {
                                productDeal.Products.Add(productModel);
                            }
                        }
                    }

                    productModel.DealPrice = productEntity.Deals
                        .Where(x => x.Deal.DealType == DealTypes.Single)
                        .FirstOrDefault()
                        .Price;
                }
            }

            var model = new HomeIndexViewModel
            {
                ProductDeals = productDeals
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #endregion
    }
}