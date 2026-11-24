using Store_Example.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Products.Queries.GetAllProductForSite
{
    public interface IGetAllProductForSite
    {
        public ResultDto<ResultGetAllProductForSiteDto> Execute(int page);
    }
}
