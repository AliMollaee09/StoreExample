using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Users.Commands.EditUser
{
	public interface IEditUserService
	{
		 ResultDto Execute(RequestEditUserDto requestEditUserDto);

	}
}
