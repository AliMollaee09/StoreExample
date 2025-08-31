using Store_Example.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Users.Queries.GetRoles
{
	public interface IGetRoles
	{
		public ResultDto<List<GetRolesDto>> Execute();
	}
}
