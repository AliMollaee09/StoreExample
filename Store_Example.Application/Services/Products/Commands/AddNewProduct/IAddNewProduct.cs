using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Products.Commands.AddNewProduct
{
	public interface IAddNewProduct
	{
		Task<ResultDto> Execute(RequestAddNewProductDto requestAddNewProductDto);
	}
}
