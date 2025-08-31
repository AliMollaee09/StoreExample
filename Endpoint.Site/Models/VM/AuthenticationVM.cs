using System.ComponentModel.DataAnnotations;

namespace Endpoint.Site.Models.VM
{
	public class AuthenticationVM
	{
		[Required(ErrorMessage = "نام و نام خانوادگی نمی‌تواند خالی باشد")]
		[MaxLength(20 ,ErrorMessage = "طول نام ونام خانوادگی زیاد است")]
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




	}
}
