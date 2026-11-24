using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Application.Services.Products.Queries.GetDetailProductForAdmin;
using Store_Example.Common.Dtos;
using Store_Example.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Products.Queries.GetDetailProductForSite
{
    public interface IGetDetailProductForSite
    {

        public Task<ResultDto<GetDetailProductForSiteDto>> Execute(long id);
    }

    public class GetDetailProductForSiteService(IDatabaseContext _context, IMapper _mapper) : IGetDetailProductForSite
    {


        public async Task<ResultDto<GetDetailProductForSiteDto>> Execute(long id)
        {
          var product=await  _context.Products
                .Include(x=>x.Category)
                .ThenInclude(x=>x.ParentCategory)
                .Include(x=>x.ProductFeatures)
                .Include(x=>x.ImageFiles)
                .SingleOrDefaultAsync(x=>x.Id== id);

            GetDetailProductForSiteDto getDetailProductForSiteDto = _mapper.Map<Product, GetDetailProductForSiteDto>(product);

            return new ResultDto<GetDetailProductForSiteDto>
            {
                Data = getDetailProductForSiteDto,
                IsSuccess = true,
                Message = "موفقیت آمیز بود"
            };
        }
    }

    public class GetDetailProductForSiteDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public string Category { get; set; }
        public bool Displayed { get; set; }

        public ICollection<DetailProductFeatureDto> DetailProductFeatureDtos { get; set; }
        public ICollection<DetailProductFileDto> DetailProductFiles { get; set; }


    }
}
