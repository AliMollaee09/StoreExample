using AutoMapper;
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
        public Task<ResultDto<GetDetailProductForAdminDto>> Execute(long Id);
    }

    public class GetDetailProductForAdminService(IDatabaseContext context, IMapper mapper) : IGetDetailProductForAdmin
    {
        public async Task<ResultDto<GetDetailProductForAdminDto>> Execute(long Id)
        {
            try
            {
               var product=await context.Products.FindAsync(Id);
                // Fix: Use the CreateMapper method to create an IMapper instance, then use the Map method to map the product to GetDetailProductForAdminDto.
               
                var getDetailProductForAdminDto = mapper.Map<GetDetailProductForAdminDto>(product);
                return new ResultDto<GetDetailProductForAdminDto>
                {
                    IsSuccess = true,
                    Message = "محصول یافت شد",
                    Data = getDetailProductForAdminDto
                };
            }
            catch (Exception ex)
            {

                return new ResultDto<GetDetailProductForAdminDto>
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد",
                    Data = new GetDetailProductForAdminDto()
                };
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

        public ICollection<DetailProductFeatureDto> detailProductFeatureDtos { get; set; }
        public ICollection<DetailProductFileDto> detailProductFiles{ get; set; }
    }

    public class DetailProductFeatureDto
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }

    public class DetailProductFileDto
    {
        public byte[] Bytes { get; set; }

    }
}
