using Endpoint.Site.Areas.Admin.Models.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Store_Example.Application.Interfaces.Facad;
using Store_Example.Application.Services.Products.Commands.AddNewCategory;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController(
        IProductFacad productFacad
        ) : Controller
    {
        public async Task<IActionResult> Index(long? parentId)
        {
            var result = await productFacad.GetCategory.Execute(parentId);
            List<GetCategoryVM> categoryVms = new();
            foreach (var itemDto in result.Data)
            {
                categoryVms.Add(new GetCategoryVM()
                {
                    Id = itemDto.Id,
                    Name = itemDto.Name,
                    HasChild = itemDto.HasChild,
                    Parent = itemDto.Parent != null ? new GetCategoryVM()
                    {
                        Id = itemDto.Parent.Id,
                        Name = itemDto.Parent.name

                    } : null
                });
            }
            return View(categoryVms);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNewCategory(string name, long? parentId)
        {
            var res = await productFacad.AddNewCategory.Execute(new RequestAddNewCategoryDto()
            {
                Name = name,
                ParentCategoryId = parentId
            });
            return Json(res);
        }
    }
}
