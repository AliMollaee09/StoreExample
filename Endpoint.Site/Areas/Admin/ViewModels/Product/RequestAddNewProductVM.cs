
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Site.Areas.Admin.ViewModels.Product
{
	public class RequestAddNewProductVM
	{

		[Required(ErrorMessage = "لطفا عنوان را وارد کنید")]
		public string Name { get; set; }

		[Required(ErrorMessage = "لطفا برند را وارد کنید")]
		public string Brand { get; set; }
		public string Description { get; set; }
		
		[Required(ErrorMessage = "لطفا قیمت را وارد کنید")]
		public int Price { get; set; }
		
		[Required(ErrorMessage = "لطفا موجودی انبار را وارد کنید")]
		public int Inventory { get; set; }
		public long CategoryId { get; set; }
		public bool Displayed { get; set; }

		public List<AddNewProduct_ImageDto> Images { get; set; }
		public List<AddNewProduct_FeaturesVM> Features { get; set; }
	}
}
