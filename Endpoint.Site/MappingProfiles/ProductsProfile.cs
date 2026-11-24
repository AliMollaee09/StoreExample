using AutoMapper;
using Endpoint.Site.Areas.Admin.Models.ViewModels.Product;
using Store_Example.Application.Services.Products.Queries.GetDetailProductForAdmin;

namespace Endpoint.Site.MappingProfiles
{
    public class ProductsProfile:Profile
    {
        public ProductsProfile()
        {
            CreateMap<GetDetailProductForAdminDto, GetDetailProductForAdminVM>();
            CreateMap<DetailProductFeatureDto, AddNewProduct_FeaturesVM>();
            CreateMap<DetailProductFileDto, AddNewProduct_ImageVM>();
        }
    }
}
