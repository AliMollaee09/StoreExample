using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Users.Commands.UserStatusChange
{
	public interface IUserStatusChangeService
	{
		ResultDto Execute(RequestUserStatusChangeDto requestUserStatusChangeDto);
	}

	public class UserStatusChangeService(IDatabaseContext context) : IUserStatusChangeService
	{
		public ResultDto Execute(RequestUserStatusChangeDto requestUserStatusChangeDto)
		{
			try
			{
				var UserForEdit = context.users.Find(requestUserStatusChangeDto.Id);
				UserForEdit.IsActive = !UserForEdit.IsActive;
				context.SaveChanges();
				return new ResultDto
				{
					IsSuccess = true,
					Message = "  کاربر با موفقیت فعال شد"
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

	public class RequestUserStatusChangeDto
	{
		public int Id { get; set; }


	}

}
