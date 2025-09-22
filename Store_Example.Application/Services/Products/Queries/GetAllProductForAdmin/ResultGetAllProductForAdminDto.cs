namespace Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin
{
    public class ResultGetAllProductForAdminDto
	{
		public int RowCount { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }

		public ICollection<ProductForAdminDto> ProductForAdminDtos { get; set; }
	}
}
