using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MemoryExpress.Core.Domain.Catalog
{
    public class ProductManufacturerMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}