using AutoMapper;
using MemoryExpress.Core.Domain.Catalog;
using MemoryExpress.Core.Services.Catalog;
using MemoryExpress.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemoryExpress.Web.Controllers
{
    public class NavController : Controller
    {
        #region Fields

        private ICategoryService _categoryService;
        private IMapper _mapper;

        #endregion

        #region Constructor

        public NavController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var categoryEntities = _categoryService.GetAllCategories()
                .Where(x => x.Published == true);
            var categoryList = new List<CategoryModel>();

            foreach (var category in categoryEntities)
            {
                var categoryModel = _mapper.Map<Category, CategoryModel>(category);

                categoryList.Add(categoryModel);
            }

            ViewBag.ReturnUrl = this.Request.Url.AbsolutePath;
            ViewData["UserInHomePage"] = this.Request.RequestContext.RouteData.Values["controller"].ToString() == "Home";

            return PartialView("~/Views/Shared/_Nav.cshtml", categoryList);
        }

        #endregion
    }
}