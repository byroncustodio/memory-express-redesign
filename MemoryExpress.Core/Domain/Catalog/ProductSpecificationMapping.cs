using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MemoryExpress.Core.Domain.Catalog
{
    public class ProductSpecificationMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int SpecificationId { get; set; }

        public string Value { get; set; }
        public int SortOrder { get; set; }

        public virtual Product Product { get; set; }
        public virtual Specification Specification { get; set; }
    }
}