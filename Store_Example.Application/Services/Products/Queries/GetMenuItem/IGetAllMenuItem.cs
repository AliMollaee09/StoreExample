using Store_Example.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Products.Queries.GetMenuItem
{
    public interface IGetAllMenuItem
    {
        public Task<ResultDto<List<ResultGetAllMenuItemDto>>> Execute();
    }
}
