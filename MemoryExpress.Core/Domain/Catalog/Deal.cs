using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MemoryExpress.Core.Domain.Catalog
{
    public enum DealTypes
    {
        Single,
        Bundle
    }

    public class Deal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DealTypes DealType { get; set; }

        public bool Published { get; set; }
        public DateTime StartDealDate { get; set; }
        public DateTime? EndDealDate { get; set; }
    }
}