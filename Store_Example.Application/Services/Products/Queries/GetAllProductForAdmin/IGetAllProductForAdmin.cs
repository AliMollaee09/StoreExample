using Store_Example.Common.Dtos;
using Store_Example.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin
{
	public interface IGetAllProductForAdmin
	{
		public Task<ResultDto<ResultGetAllProductForAdminDto>> Execute(int pageSize, int currentPage);
	}
}
