using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryExpress.Web.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeoUrl { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}