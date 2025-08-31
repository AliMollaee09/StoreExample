using Store_Example.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Users.Commands.RegisterUser
{
	public interface IRegisterUserService
	{
		public ResultDto<ResultRegisterUser> Execute(RequestRegisterUser request);
	}
}
