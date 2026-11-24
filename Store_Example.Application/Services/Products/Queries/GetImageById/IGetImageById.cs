using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Products.Queries.GetImageById
{
    public interface IGetImageById
    {
        public Task<ResultDto<ResultGetImageByIdDto>> Execute(long id);
    }

    public class GetImageByIdService : IGetImageById
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;

        public GetImageByIdService(IDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<ResultGetImageByIdDto>> Execute(long id)
        {
            var image = await _context.ProductFiles.Select(x => new ResultGetImageByIdDto
            {
                Id = x.Id,
                Bytes = x.Bytes,
            }).FirstOrDefaultAsync(x => x.Id == id);
            return new ResultDto<ResultGetImageByIdDto>
            {
                Data = image,
                IsSuccess = true,
                Message = "موفقیت آمیز"
            };
        }
    }
    public class ResultGetImageByIdDto
    {
        public long Id { get; set; }

        public byte[] Bytes { get; set; }
    }
}
