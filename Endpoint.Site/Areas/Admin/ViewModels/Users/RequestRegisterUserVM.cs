using System.ComponentModel.DataAnnotations;
using Endpoint.Site.Areas.Admin.ViewModels.Roles;
using Store_Example.Application.Services.Users.Commands.RegisterUser;

namespace Endpoint.Site.Areas.Admin.ViewModels.Users
{
	public class RequestRegisterUserVM
	{
		[Required(ErrorMessage = "نام و نام خانوادگی نمی‌تواند خالی باشد")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "ایمیل نمی‌تواند خالی باشد")]
		[EmailAddress(ErrorMessage = "ایمیل صحیح وارد کنید")]
		public string Email { get; set; }

		[Required(ErrorMessage = "رمز عبور نمی‌تواند خالی باشد")]
		[MinLength(6, ErrorMessage = "رمز عبور باید حداقل 6 کاراکتر باشد")]
		public string Password { get; set; }

		[Required(ErrorMessage = "تکرار رمز عبور نمی‌تواند خالی باشد")]
		[Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیستند")]
		public string RePassword { get; set; }

		public List<RolesInRegisterUserVM> Roles { get; set; }

	}
}
