using Store_Example.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin
{
	public interface IGetAllProductForAdmin
	{
		public Task<ResultDto<ResultGetAllProductForAdminDto>> Execute(int pageSize, int currentPage);
	}

	public class GetAllProductForAdmin : IGetAllProductForAdmin
	{
		private readonly IDatabaseContext _context;

		public GetAllProductForAdmin(IDatabaseContext context)
		{
			_context = context;
		}
		public async Task<ResultDto<ResultGetAllProductForAdminDto>> Execute(int pageSize, int currentPage)
		{

			try
			{
				int rowCount;
				var ProductForAdmins =  _context.Products
														 .Include(x => x.Category)
														 .Select(p => new ProductForAdminDto()
														 {
															 Id=p.Id,
															 Brand = p.Brand,
															 Category = p.Category.Name,
															 Description = p.Description,
															 Displayed = p.Displayed,
															 Name = p.Name,
															 Inventory = p.Inventory,
															 Price = p.Price
														 })
														 .ToPaged(currentPage, pageSize, out rowCount);
				return new ResultDto<ResultGetAllProductForAdminDto>()
				{
					Data = new ResultGetAllProductForAdminDto()
					{
						CurrentPage = currentPage,
						PageSize = pageSize,
						RowCount = rowCount,
						ProductForAdminDtos = ProductForAdmins.ToList()
					},
					IsSuccess = true,
					Message = "موفقیت آمیز"
				};
			}
			catch (Exception ex)
			{

				return new ResultDto<ResultGetAllProductForAdminDto>()
				{
					Data = new ResultGetAllProductForAdminDto(),
					IsSuccess = false,
					Message = "شکست"
				};
			}


		}
	}

	public class ResultGetAllProductForAdminDto
	{
		public int RowCount { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }

		public ICollection<ProductForAdminDto> ProductForAdminDtos { get; set; }
	}

	public class ProductForAdminDto
	{

        public long Id { get; set; }
        public string Name { get; set; }
		public string Brand { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int Inventory { get; set; }
		public bool Displayed { get; set; }
		public string Category { get; set; }
	}
}
