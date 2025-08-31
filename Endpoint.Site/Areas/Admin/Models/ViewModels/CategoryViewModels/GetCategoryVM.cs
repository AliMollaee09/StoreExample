using Store_Example.Application.Services.Products.Queries.GetCategory;

namespace Endpoint.Site.Areas.Admin.Models.ViewModels.CategoryViewModels
{
	public class GetCategoryVM
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool? HasChild { get; set; }
		public GetCategoryVM? Parent { get; set; }
	}
}
