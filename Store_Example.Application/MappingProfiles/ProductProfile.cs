using AutoMapper;
using Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin;
using Store_Example.Application.Services.Products.Queries.GetAllProductForSite;
using Store_Example.Application.Services.Products.Queries.GetDetailProductForAdmin;
using Store_Example.Application.Services.Products.Queries.GetDetailProductForSite;
using Store_Example.Application.Services.Products.Queries.GetMenuItem;
using Store_Example.Domain.Entities.Commons.ExtentionMethods;
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

            CreateMap<Product, GetDetailProductForAdminDto>()
                .ForMember(des => des.Category, opt => opt.MapFrom(src => src.Category.GetFullName()))
                .ForMember(des=>des.DetailProductFiles,opt=>opt.MapFrom(src=>src.ImageFiles))
                .ForMember(des=>des.DetailProductFeatureDtos,opt=>opt.MapFrom(src=>src.ProductFeatures));

            CreateMap<ProductFeature, DetailProductFeatureDto>();
            CreateMap<ProductFile, DetailProductFileDto>();

            CreateMap<Product, GetAllProductForSiteDto>()
                .ForMember(des => des.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(des => des.Image, opt => opt.MapFrom(src => src.ImageFiles.FirstOrDefault().Bytes))
                .ForMember(des => des.Star, opt => opt.MapFrom(src => new Random().Next(1, 5)));

            CreateMap<Product, GetDetailProductForSiteDto>()
               .ForMember(des => des.Category, opt => opt.MapFrom(src => src.Category.GetFullName()))
               .ForMember(des => des.DetailProductFiles, opt => opt.MapFrom(src => src.ImageFiles))
               .ForMember(des => des.DetailProductFeatureDtos, opt => opt.MapFrom(src => src.ProductFeatures));

            CreateMap<Category, ResultGetAllMenuItemDto>()
                .ForMember(des => des.CatId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name));

        }


    }
}
