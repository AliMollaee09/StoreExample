using Endpoint.Site.Areas.Admin.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Application.Interfaces.Facad;
using Store_Example.Application.Services.Products.Commands.AddNewProduct;
using Store_Example.Application.Services.Products.Facad;
using System.Threading.Tasks;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductFacad productFacad) : Controller
    {
        public async Task<IActionResult> Index(int currentPage = 1, int pageSize = 20)
        {
            var products = (await productFacad.GetAllProductForAdmin.Execute(pageSize, currentPage)).Data;
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewProduct()
        {
            ViewBag.Categories = new SelectList((await productFacad.GetAllCategory.Execute()).Data, "Id", "Name");
            return View(new RequestAddNewProductVM());
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(RequestAddNewProductDto request, List<AddNewProduct_FeaturesDto> features)
        {
            request.Features = features;
            var res = await productFacad.AddNewProduct.Execute(request);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await productFacad.DeleteProduct.Excute(id);
            return Json(res);
        }

        public async Task<IActionResult> DetailProduct(long id)
        {
            var res = await productFacad.GetDetailProductForAdmin.Execute(id);
            return Json(res);
        }
    }
}
