using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MemoryExpress.Core.Domain.Catalog
{
    public class ProductImageMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int ImageId { get; set; }

        public int SortOrder { get; set; }

        public virtual Product Product { get; set; }
        public virtual Image Image { get; set; }
    }
}