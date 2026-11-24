using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Products.Queries.GetAllProductForSite
{
    public class GetAllProductForSiteService : IGetAllProductForSite
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllProductForSiteService(IDatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ResultGetAllProductForSiteDto> Execute(int page)
        {
            try
            {
                int TotalRow;
                var products = _context.Products.Include(x=>x.ImageFiles).ToPaged(page, 5, out TotalRow).ToList();
               List< GetAllProductForSiteDto> resultGetAllProductForSiteDto = _mapper.Map<List<GetAllProductForSiteDto>>(products);
                return new ResultDto<ResultGetAllProductForSiteDto>
                {
                    Data =new ResultGetAllProductForSiteDto
                    {
                        GetAllProductForSiteDtos = resultGetAllProductForSiteDto,
                        TotalRow = TotalRow
                    },
                    IsSuccess = true,
                    Message = "موفق بود"
                };
            }
            catch (Exception ex)
            {

                return new ResultDto<ResultGetAllProductForSiteDto>
                {
                    Data = new ResultGetAllProductForSiteDto(),
                    IsSuccess = false,
                    Message = "ناموفق بود "+ Environment.NewLine + ex.Message
                };

            }
        }
    }
}
