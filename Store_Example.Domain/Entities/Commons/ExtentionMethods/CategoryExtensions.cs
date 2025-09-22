using Store_Example.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Domain.Entities.Commons.ExtentionMethods
{
    public static class CategoryExtensions
    {
        public static string GetFullName(this Category category)
        {
            if (category == null)
                return null;

            if (category.ParentCategoryId != null && category.ParentCategory != null)
                return category.ParentCategory.Name + " " + category.Name;

            return category.Name;
        }
    }
}
