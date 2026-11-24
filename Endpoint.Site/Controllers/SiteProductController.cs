using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Facad;
using Store_Example.Application.Services.Products.Queries.GetAllProductForSite;
using Store_Example.Domain.Entities.Products;
using System.Threading.Tasks;

namespace Endpoint.Site.Controllers
{
    public class SiteProductController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IMapper _mapper;

        public SiteProductController(IProductFacad productFacad,IMapper mapper)
        {
            _productFacad = productFacad;
            _mapper = mapper;
        }

        public IActionResult Index(int page=1)
        {
            var products = _productFacad.GetAllProductForSite.Execute(page);
            return View(products.Data);
        }

        public async Task<IActionResult> Detail(int id)
        {

            var productDto=await _productFacad.GetDetailProductForSite.Execute(id);
            return View(productDto.Data);
        }

        public async Task<IActionResult> Image(long id)
        {
            var file = (await _productFacad.GetImageById.Execute(id)).Data;
            return File(file.Bytes, "image/jpeg");
        }

    }
}
