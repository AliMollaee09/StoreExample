using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin
{
    public class GetAllProductForAdmin : IGetAllProductForAdmin
	{
		private readonly IDatabaseContext _context;
        private readonly IConfigurationProvider _mapperConfig;

        public GetAllProductForAdmin(IDatabaseContext context, IConfigurationProvider mapperConfig)
		{
			_context = context;
            _mapperConfig = mapperConfig;
        }
		public async Task<ResultDto<ResultGetAllProductForAdminDto>> Execute(int pageSize, int currentPage)
		{

			try
			{
				int rowCount;
				var ProductForAdmins =  _context.Products
														 .Include(x => x.Category)
														 .ProjectTo<ProductForAdminDto>(_mapperConfig)
               //                                          .Select(p => new ProductForAdminDto()
														 //{
															// Id=p.Id,
															// Brand = p.Brand,
															// Category = p.Category.Name,
															// Description = p.Description,
															// Displayed = p.Displayed,
															// Name = p.Name,
															// Inventory = p.Inventory,
															// Price = p.Price
														 //})
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
}
