using MemoryExpress.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryExpress.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<HomeProductDealViewModel> ProductDeals { get; set; }
    }

    public class HomeProductDealViewModel
    {
        public string DealName { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}