using Endpoint.Site.Areas.Admin.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Application.Interfaces.Facad;
using Store_Example.Application.Services.Products.Commands.AddNewProduct;
using Store_Example.Application.Services.Products.Facad;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductFacad productFacad) : Controller
    {
        public IActionResult Index()
        {
            return View();
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
	       var res= await productFacad.AddNewProduct.Execute(request);
            return Json(res);
        }
    }
}
