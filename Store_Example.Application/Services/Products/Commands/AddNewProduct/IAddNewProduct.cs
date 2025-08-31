using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;
using Store_Example.Domain.Entities.Products;

namespace Store_Example.Application.Services.Products.Commands.AddNewProduct
{
	public interface IAddNewProduct
	{
		Task<ResultDto> Execute(RequestAddNewProductDto requestAddNewProductDto);
	}

	public class AddNewProductService(IDatabaseContext context) : IAddNewProduct
	{
		public async Task<ResultDto> Execute(RequestAddNewProductDto requestAddNewProductDto)
		{
			try
			{
				var category = context.Categories.Find(requestAddNewProductDto.CategoryId);
				List<ProductFile> productFiles = new();

				List<ProductFeature> productFeatures = null!;



				if (requestAddNewProductDto.Images?.Count > 0)
				{
					foreach (var file in requestAddNewProductDto.Images)
					{
						using var ms = new MemoryStream();
						file.CopyTo(ms);
						productFiles.Add(new ProductFile() { Bytes = ms.ToArray() });

					}
				}

				if (requestAddNewProductDto.Features?.Count > 0)
				{

					productFeatures = requestAddNewProductDto.Features
					   .Select(r => new ProductFeature() { DisplayName = r.DisplayName, Value = r.Value }).ToList();
				}

				await context.Products.AddAsync(new Product()
				{
					Brand = requestAddNewProductDto.Brand,
					Name = requestAddNewProductDto.Name,
					CategoryId = requestAddNewProductDto.CategoryId,
					//Category = category,
					Description = requestAddNewProductDto.Description,
					Displayed = requestAddNewProductDto.Displayed,
					Inventory = requestAddNewProductDto.Inventory,
					Price = requestAddNewProductDto.Price,
					ImageFiles = productFiles,
					ProductFeatures = productFeatures,
				});

				await context.SaveChangesAsync();
				return new ResultDto()
				{
					IsSuccess = true,
					Message = "محصول جدید با موفقیت اضافه شد"
				};
			}
			catch (Exception ex)
			{

				return new ResultDto()
				{
					IsSuccess = false,
					Message = "محصول جدید با موفقیت اضافه شد"
				};
			}

		}
	}
}
