using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store_Example.Application.Services.Users.Commands.DeleteUser;
using Store_Example.Application.Services.Users.Commands.EditUser;
using Store_Example.Application.Services.Users.Commands.RegisterUser;
using Store_Example.Application.Services.Users.Commands.UserStatusChange;
using Store_Example.Application.Services.Users.Queries.GetRoles;
using Store_Example.Application.Services.Users.Queries.GetUsers;
using Store_Example.Common.Dtos;

namespace Endpoint.Site.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UsersController(
		IGetUsersService usersService,
		IRegisterUserService registerUserService,
		IGetRoles getRoles,
		IEditUserService editUserService,
		IDeleteUserService deleteUserService,
		IUserStatusChangeService userStatusChangeService)
		: Controller
	{


		public IActionResult Index(RequestGetUsersdto request)
		{
			var users= usersService.Execute(request);
			return View(users);
		}

		[HttpGet]
		public IActionResult Create(/*RequestRegisterUser request*/)
		{
			ViewBag.Roles = new SelectList( getRoles.Execute().Data, "RoleId", "Name");
			//var result = _registerUserService.Execute(request);
			return View();
		}

		[HttpPost]
		public IActionResult Create(string fullName,string email,string password,string rePasword, int roleId)
		{

			var result = registerUserService.Execute(new RequestRegisterUser()
			{
				FullName = fullName,
				Email = email,
				Password = password,
				RePasword = rePasword,
				Roles = new List<RolesInRegisterUserDto>()
				{
					new ()
					{
						Id = roleId

					}
				}
			});
			return Json(result);
		}


		[HttpPost]
		public IActionResult Edit(int userId, string fullname)
		{

			var result = editUserService.Execute(new RequestEditUserDto()
			{
				Id = userId,
				FullName = fullname
			});

			return Json(result);
		}

		[HttpPost]
		public IActionResult Delete(int userId)
		{

			var result = deleteUserService.Execute(new RequestDeleteUser()
			{
				Id = userId,
			});

			return Json(result);
		}

		[HttpPost]
		public IActionResult UserSatusChange(int userId )
		{

			var result = userStatusChangeService.Execute(new RequestUserStatusChangeDto()
			{
				Id = userId
			});

			return Json(result);
		}
	}
}
 