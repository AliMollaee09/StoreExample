using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Services.Products.Commands.DeleteProduct
{
    public interface IDeleteProduct
    {
        public Task<ResultDto> Excute(long Id);
    }

    public class DeleteProductService(IDatabaseContext context) : IDeleteProduct
    {

        public async Task<ResultDto> Excute(long Id)
        {
            try
            {
                var product= await context.Products.FindAsync(Id);
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return new ResultDto { IsSuccess = true , Message="حذف با موفقیت انجام شد"};
            }
            catch (Exception ex)
            {

                return new ResultDto { IsSuccess = false, Message = "حذف با شکست مواجه شد" };

            }
        }
    }

}
