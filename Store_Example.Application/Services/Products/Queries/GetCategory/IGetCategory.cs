using Store_Example.Common.Dtos;
using Store_Example.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;

namespace Store_Example.Application.Services.Products.Queries.GetCategory
{
	public interface IGetCategory
	{
		Task<ResultDto<List<ResultCategoriesDto>>> Execute(long? parentId);
	}

	public  class GetCategoryService(IDatabaseContext context) : IGetCategory
	{
		public async Task<ResultDto<List<ResultCategoriesDto>>> Execute(long? parentId)
		{
			var categories = await context.Categories.Include(x => x.ParentCategory)
				.Include(x => x.SubCategories)
				.Where(x => x.ParentCategoryId == parentId)
				.Select(x => new ResultCategoriesDto
				{
					Id = x.Id,
					Name = x.Name,
					Parent = x.ParentCategoryId != null
						? new ParentCategoryDto()
						{
							Id = x.ParentCategory.Id,
							name = x.ParentCategory.Name
						}
						: null,
					HasChild = x.SubCategories.Count > 0
				})
				.ToListAsync();

			return new ResultDto<List<ResultCategoriesDto>>
			{
				Message = "لیست باموقیت برگشت داده شد",
				IsSuccess = true,
				Data = categories
			};
		}
	}

	public class ResultCategoriesDto
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public bool HasChild { get; set; }
		public ParentCategoryDto? Parent { get; set; }

	}
	public class ParentCategoryDto
	{
		public long Id { get; set; }
		public string name { get; set; }
	}
}
