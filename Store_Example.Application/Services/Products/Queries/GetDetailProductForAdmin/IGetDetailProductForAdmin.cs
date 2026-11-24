using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Products.Queries.GetDetailProductForAdmin
{
    public interface IGetDetailProductForAdmin
    {
        public Task<GetDetailProductForAdminDto> Execute(long Id);
    }

    public class GetDetailProductForAdminService(IDatabaseContext context, IMapper mapper) : IGetDetailProductForAdmin
    {
        public async Task<GetDetailProductForAdminDto> Execute(long id)
        {
            try
            {
               var product=await context.Products.Include(x=>x.ProductFeatures)
                                                 .Include(x=>x.ImageFiles).FirstOrDefaultAsync(x=>x.Id==id);
                // Fix: Use the CreateMapper method to create an IMapper instance, then use the Map method to map the product to GetDetailProductForAdminDto.
               
                var getDetailProductForAdminDto = mapper.Map<GetDetailProductForAdminDto>(product);
                return getDetailProductForAdminDto;
            }
            catch (Exception ex)
            {

                return  new GetDetailProductForAdminDto();
            }
        }
    }

    public class GetDetailProductForAdminDto
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
        public ICollection<DetailProductFileDto> DetailProductFiles{ get; set; }
    }

    public class DetailProductFeatureDto
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }

    public class DetailProductFileDto
    {
        public long Id { get; set; }
        public byte[] Bytes { get; set; }

    }
}
