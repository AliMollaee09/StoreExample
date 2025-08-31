using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;
using Store_Example.Domain.Entities.Products;

namespace Store_Example.Application.Services.Products.Commands.AddNewCategory;

public class AddNewCategoryService(IDatabaseContext context) : IAddNewCategory
{
	public async Task<ResultDto> Execute(RequestAddNewCategoryDto addNewCategoryDto)
	{
		try
		{
			await context.Categories.AddAsync(new Category
			{
				Name = addNewCategoryDto.Name,
				ParentCategoryId = addNewCategoryDto.ParentCategoryId
			});

			await context.SaveChangesAsync();

			return new ResultDto()
			{
				IsSuccess = true,
				Message = "دسته بندی با موفقیت اضافه شد"
			};
		}
		catch (Exception ex)
		{

			return new ResultDto()
			{
				IsSuccess = false,
				Message = "اضافه کردن دسته بندی  با خطا مواجه شد"
			};
		}
	}
}