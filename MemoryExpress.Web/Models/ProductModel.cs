using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryExpress.Web.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            ProductImages = new List<string>();
            Categories = new List<CategoryModel>();
            Manufacturers = new List<ManufacturerModel>();
            Specifications = new List<SpecificationModel>();
        }

        public int Id { get; set; }

        public string SKU { get; set; }

        public string ILC { get; set; }

        public string PartNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string MainImage { get; set; }

        public List<string> ProductImages { get; set; }

        public string SeoUrl { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public DateTime DateAdded { get; set; }

        public List<CategoryModel> Categories { get; set; }

        public List<ManufacturerModel> Manufacturers { get; set; }

        public List<SpecificationModel> Specifications { get; set; }
    }
}