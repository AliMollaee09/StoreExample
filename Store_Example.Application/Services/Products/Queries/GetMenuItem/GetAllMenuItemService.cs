using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Products.Queries.GetMenuItem
{
    public class GetAllMenuItemService(IDatabaseContext context, IMapper mapper) : IGetAllMenuItem
    {
        public async Task<ResultDto<List<ResultGetAllMenuItemDto>>> Execute()
        {
            var categories = await context.Categories.Include(x => x.SubCategories).Where(x=>x.ParentCategoryId==null).ToListAsync();
            List<ResultGetAllMenuItemDto> resultGetAllMenuItemDtos = mapper.Map<List<ResultGetAllMenuItemDto>>(categories);

            return new ResultDto<List<ResultGetAllMenuItemDto>>
            {
                Data = resultGetAllMenuItemDtos,
                IsSuccess = true,
                Message = "موققیت آمیز بود"
            };
        }
    }
}
