using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Users.Commands.DeleteUser;

public class DeleteUserService(IDatabaseContext context) : IDeleteUserService
{
	public ResultDto Execute(RequestDeleteUser requestDeleteUser)
	{
		try
		{
			var userForDelete = context.users.Find(requestDeleteUser.Id);
			context.users.Remove(userForDelete);
			context.SaveChanges();
			return new()
			{
				IsSuccess = true,
				Message = "حذف کاربر باموفقِت انجام شد"
			};
		}
		catch (Exception ex)
		{

			return new()
			{
				IsSuccess = true,
				Message = "حذف کاربر  انجام نشد"
			};
		}
	}
}