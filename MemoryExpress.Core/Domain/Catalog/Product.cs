using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MemoryExpress.Core.Domain.Catalog
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SKU { get; set; }
        public string ILC { get; set; }
        public string PartNumber { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
        public int MaxCartQuantity { get; set; }

        public string SeoUrl { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        public bool Published { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<ProductCategoryMapping> Categories { get; set; }
        public virtual ICollection<ProductDealMapping> Deals { get; set; }
        public virtual ICollection<ProductImageMapping> Images { get; set; }
        public virtual ICollection<ProductManufacturerMapping> Manufacturers { get; set; }
        public virtual ICollection<ProductSpecificationMapping> Specifications { get; set; }
    }
}