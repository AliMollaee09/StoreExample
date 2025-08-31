using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Application.Interfaces.Facad;
using Store_Example.Application.Services.Products.Commands.AddNewCategory;
using Store_Example.Application.Services.Products.Commands.AddNewProduct;
using Store_Example.Application.Services.Products.Queries.GetAllCategory;
using Store_Example.Application.Services.Products.Queries.GetCategory;

namespace Store_Example.Application.Services.Products.Facad
{
    public class ProductFacad(IDatabaseContext context):IProductFacad
    {
        private IAddNewCategory _addNewCategory ;
        public IAddNewCategory AddNewCategory {
			get
			{
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(context);
			}
        }

        private IGetCategory _getCategory { get; set; }

        public IGetCategory GetCategory
        {
	        get
	        {
                return _getCategory= _getCategory ?? new GetCategoryService(context);
	        }
        }

        private IGetAllCategory _getAllCategory { get; set; }

        public IGetAllCategory GetAllCategory
        {
            get
            {
                return _getAllCategory = _getAllCategory ?? new GetAllCategoryService(context);
            }
        }

		private IAddNewProduct _addNewProduct { get; set; }

		public IAddNewProduct AddNewProduct
		{
			get
			{
				return _addNewProduct = _addNewProduct ?? new AddNewProductService(context);
			}
		}
	}
}
