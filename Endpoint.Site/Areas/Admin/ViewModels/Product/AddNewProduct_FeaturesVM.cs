using System.ComponentModel.DataAnnotations;

namespace Endpoint.Site.Areas.Admin.ViewModels.Product;

public class AddNewProduct_FeaturesVM
{
	[Required(ErrorMessage = "لطفا نام ویژکی را وارد کنید")]
	public string DisplayName { get; set; }

	[Required(ErrorMessage = "لطفا مقدار ویژکی را وارد کنید")]
	public string Value { get; set; }
}