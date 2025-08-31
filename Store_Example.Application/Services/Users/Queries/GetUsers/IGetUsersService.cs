using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Users.Queries.GetUsers
{
	public interface IGetUsersService
	{
		public ResultGetUsersDto Execute(RequestGetUsersdto request);
	}
}
