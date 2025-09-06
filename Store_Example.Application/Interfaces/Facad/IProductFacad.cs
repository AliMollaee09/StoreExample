using Store_Example.Application.Services.Products.Commands.AddNewCategory;
using Store_Example.Application.Services.Products.Queries.GetCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Application.Services.Products.Commands.AddNewProduct;
using Store_Example.Application.Services.Products.Queries.GetAllCategory;
using Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin;

namespace Store_Example.Application.Interfaces.Facad
{
    public interface IProductFacad
    {
        public IAddNewCategory AddNewCategory { get; }
        public IGetCategory GetCategory { get; }
        public IGetAllCategory GetAllCategory { get; }
        public IAddNewProduct AddNewProduct { get; }

        /// <summary>
        /// دریافت لیست محصولات برای پنل ادمین
        /// </summary>
        public IGetAllProductForAdmin GetAllProductForAdmin { get; }

    }
}
