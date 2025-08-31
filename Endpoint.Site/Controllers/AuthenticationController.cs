using Endpoint.Site.Models.VM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Store_Example.Application.Services.Users.Commands.RegisterUser;
using System.Security.Claims;

namespace Endpoint.Site.Controllers
{
    public class AuthenticationController(IRegisterUserService registerUserService) : Controller
    {



        [HttpGet]
        public IActionResult SineUp()
        {

            return View(new AuthenticationVM());
        }

        [HttpPost]
        public IActionResult SineUp(SignupViewModel request)
        {
            var result = registerUserService.Execute(new RequestRegisterUser()
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                RePasword = request.RePassword,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto()
                    {
                        Id = 3
                    }
                }
            });

            if (result.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,result.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Name, request.FullName),
                    new Claim(ClaimTypes.Role, "Customer"),
                };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(result);
        }
    }
}
