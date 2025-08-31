using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Users.Commands.DeleteUser
{
	public interface IDeleteUserService
	{
		ResultDto Execute(RequestDeleteUser requestDeleteUser );
	}
}
