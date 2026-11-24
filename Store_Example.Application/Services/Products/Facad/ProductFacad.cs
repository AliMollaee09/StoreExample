using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Application.Interfaces.Facad;
using Store_Example.Application.Services.Products.Commands.AddNewCategory;
using Store_Example.Application.Services.Products.Commands.AddNewProduct;
using Store_Example.Application.Services.Products.Commands.DeleteProduct;
using Store_Example.Application.Services.Products.Queries.GetAllCategory;
using Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin;
using Store_Example.Application.Services.Products.Queries.GetAllProductForSite;
using Store_Example.Application.Services.Products.Queries.GetCategory;
using Store_Example.Application.Services.Products.Queries.GetDetailProductForAdmin;
using Store_Example.Application.Services.Products.Queries.GetDetailProductForSite;
using Store_Example.Application.Services.Products.Queries.GetImageById;
using Store_Example.Application.Services.Products.Queries.GetMenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Products.Facad
{
    public class ProductFacad(IDatabaseContext context, IConfigurationProvider mapperConfig, IMapper mapper) : IProductFacad
    {
        private IAddNewCategory _addNewCategory;
        public IAddNewCategory AddNewCategory
        {
            get
            {
                return _addNewCategory ??= new AddNewCategoryService(context);
            }
        }

        private IGetCategory _getCategory { get; set; }

        public IGetCategory GetCategory
        {
            get
            {
                return _getCategory ??= new GetCategoryService(context);
            }
        }

        private IGetAllCategory _getAllCategory { get; set; }

        public IGetAllCategory GetAllCategory
        {
            get
            {
                return _getAllCategory ??= new GetAllCategoryService(context);
            }
        }

        private IAddNewProduct _addNewProduct { get; set; }

        public IAddNewProduct AddNewProduct
        {
            get
            {
                return _addNewProduct ??= new AddNewProductService(context);
            }
        }

        private IGetAllProductForAdmin _getAllProductForAdmin;

        public IGetAllProductForAdmin GetAllProductForAdmin
        {
            get
            {
                return _getAllProductForAdmin ??= new GetAllProductForAdmin(context, mapperConfig);
            }
        }

        private IDeleteProduct _deleteProduct;

        public IDeleteProduct DeleteProduct
        {
            get
            {
                return _deleteProduct ??= new DeleteProductService(context);
            }
        }

        private IGetDetailProductForAdmin _getDetailProductForAdmin;

        public IGetDetailProductForAdmin GetDetailProductForAdmin
        {
            get
            {
                return _getDetailProductForAdmin ??= new GetDetailProductForAdminService(context, mapper);
            }
        }

        private IGetAllProductForSite _getAllProductForSite;

        public IGetAllProductForSite GetAllProductForSite
        {
            get
            {
                return _getAllProductForSite ??= new GetAllProductForSiteService(context, mapper);
            }
        }

        private IGetDetailProductForSite _gtDetailProductForSite;

        public IGetDetailProductForSite GetDetailProductForSite
        {
            get
            {
                return _gtDetailProductForSite ??= new GetDetailProductForSiteService(context, mapper);
            }
        }

        private IGetImageById _getImageById;

        public IGetImageById GetImageById
        {
            get
            {
                return _getImageById ??= new GetImageByIdService(context, mapper);
            }
        }

        private IGetAllMenuItem _getAllMenuItem;
        public IGetAllMenuItem GetAllMenuItem
        {

            get
            {
                return _getAllMenuItem ??= new GetAllMenuItemService(context, mapper);
            }

        }
    }
}