using System.ComponentModel.DataAnnotations;

namespace Endpoint.Site.Areas.Admin.Models.ViewModels.Product;

public class AddNewProduct_FeaturesVM
{
    public long Id { get; set; }
    [Required(ErrorMessage = "لطفا نام ویژکی را وارد کنید")]
	public string DisplayName { get; set; }

	[Required(ErrorMessage = "لطفا مقدار ویژکی را وارد کنید")]
	public string Value { get; set; }
}