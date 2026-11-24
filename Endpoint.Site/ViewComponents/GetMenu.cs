using Microsoft.AspNetCore.Mvc;
using Store_Example.Application.Interfaces.Facad;
using Store_Example.Application.Services.Products.Facad;
using System.Threading.Tasks;

namespace Endpoint.Site.ViewComponents
{
    public class GetMenu(IProductFacad productFacad):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var lstMenu = productFacad.GetAllMenuItem.Execute().Result;
            return View(viewName:"GetMenu",model: lstMenu.Data);
        }
    }
}
