using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MemoryExpress.Core.Domain.Catalog
{
    public class ProductDealMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int DealId { get; set; }
        public decimal Price { get; set; }

        public string MainImage { get; set; }

        public virtual Product Product { get; set; }
        public virtual Deal Deal { get; set; }
    }
}