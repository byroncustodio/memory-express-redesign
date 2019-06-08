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
            var productEntities = _productService.GetAllProducts()
                .Where(x => x.Published == true);
            var productList = new List<ProductModel>();

            foreach (var product in productEntities)
            {
                var productModel = _mapper.Map<Product, ProductModel>(product);

                // get main image
                if (product.Images.Count() > 0)
                {
                    productModel.MainImage = product.Images
                        .OrderBy(x => x.SortOrder)
                        .FirstOrDefault()
                        .Image
                        .FileName;
                }

                // check for discount

                // get product rating

                productList.Add(productModel);
            }

            return View(productList);
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