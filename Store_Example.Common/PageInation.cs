using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Common
{
	public static class PageInation
	{ 
		public static async Task<IEnumerable<TSource>> ToPagedAsync<TSource>(this IEnumerable< TSource> source, int page,int pageSize,out int rowsCont)
		{
			rowsCont=source.Count();
			return source.Skip((page -1)* pageSize).Take(pageSize);
		}
	}
}
