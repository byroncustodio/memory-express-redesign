using AutoMapper;
using MemoryExpress.Core.Domain.Catalog;
using MemoryExpress.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryExpress.Web.Helpers
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Manufacturers, opt => opt.Ignore())
                .ForMember(dest => dest.Specifications, opt => opt.Ignore());
        }
    }
}