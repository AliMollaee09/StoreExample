using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Products.Queries.GetAllCategory
{
	public interface IGetAllCategory
	{
		Task<ResultDto<List<ResultGetAllCategoryDto>>> Execute();
	}

	public class GetAllCategoryService(IDatabaseContext context) : IGetAllCategory
	{
		public async Task<ResultDto<List<ResultGetAllCategoryDto>>> Execute()
		{
			var resultData = await context.Categories.Include(x => x.ParentCategory)
																			  .Where(x => x.ParentCategoryId != null)
																			  .Select(x => new ResultGetAllCategoryDto()
																			  {
																				  Id = x.Id,
																				  Name = x.ParentCategory.Name + " - "+ x.Name
																			  }).ToListAsync();

			return new ResultDto<List<ResultGetAllCategoryDto>>()
			{
				IsSuccess = true,
				Message = "موفقیت آمیزبود",
				Data = resultData
			};
		}
	}


	public class ResultGetAllCategoryDto
	{
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
