using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;
using Store_Example.Domain.Entities.Users;

namespace Store_Example.Application.Services.Users.Commands.RegisterUser
{
	public class  RegisterUserService : IRegisterUserService
	{
		private readonly IDatabaseContext _context;

		public RegisterUserService(IDatabaseContext context)
		{
			_context = context;
		}

		public ResultDto<ResultRegisterUser> Execute(RequestRegisterUser request)
		{
			try
			{
				User user = new User
				{
					FullName = request.FullName,
					Email = request.Email,
					Password = request.Password
					
				};

				List<UserInRole> roles = new List<UserInRole>();
				foreach (var item in request.Roles)
				{
					var role = _context.Roles.Find(item.Id);
					roles.Add(new UserInRole
					{
						RoleId = role.Id,
						Role = role,
						UserId = user.Id
					});
				}
				user.UserInRoles = roles;
				_context.users.Add(user);
				_context.SaveChanges();

				return new ResultDto<ResultRegisterUser>
				{
					Data = new ResultRegisterUser { UserId = user.Id },
					Message = "ثبت نام کاربر انجام شد",
					IsSuccess = true,
				};
			}
			catch (Exception ex)
			{

				return new ResultDto<ResultRegisterUser>
				{
					Data = new ResultRegisterUser { UserId = 0 },
					Message = "ثبت نام کاربر انجام نشد",
					IsSuccess = false,
				};
			}
		}
	}
}
