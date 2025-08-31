using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Application.Services.Users.Commands.RegisterUser;
using Store_Example.Common.Dtos;

namespace Store_Example.Application.Services.Products.Commands.AddNewCategory
{
    public interface IAddNewCategory
    {
        public  Task<ResultDto> Execute(RequestAddNewCategoryDto addNewCategoryDto);
    }
}
