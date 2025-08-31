using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Users.Commands.EditUser;

public class EditUserService(IDatabaseContext context) : IEditUserService
{
	public ResultDto Execute(RequestEditUserDto requestEditUserDto)
	{
		try
		{

			var userForEdit =  context.users.Find(requestEditUserDto.Id);
			userForEdit.FullName = requestEditUserDto.FullName;
			context.SaveChanges();
			return  new ResultDto
			{
				IsSuccess = true,
				Message = "ویرایش  کاربر با موفقیت انجام شد"
			};
		}
		catch (Exception ex)
		{
			return new ResultDto
			{
				IsSuccess = false,
				Message = "ویرایش  کاربر انجام نشد"
			};
		}
	}
}