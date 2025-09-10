using AutoMapper;
using Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin;
using Store_Example.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.MappingProfiles
{
    public class ProductProfile : Profile // Inherit from AutoMapper.Profile
    {
        public ProductProfile()
        {
            // Fixing the syntax error by providing the correct lambda expression and method call
            CreateMap<Product, ProductForAdminDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
