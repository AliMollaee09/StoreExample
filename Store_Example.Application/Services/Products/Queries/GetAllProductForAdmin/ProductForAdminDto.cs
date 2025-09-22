namespace Store_Example.Application.Services.Products.Queries.GetAllProductForAdmin
{
    public class ProductForAdminDto
	{

        public long Id { get; set; }
        public string Name { get; set; }
		public string Brand { get; set; }
		public int Price { get; set; }
		public int Inventory { get; set; }
		public bool Displayed { get; set; }
		public string Category { get; set; }
	}
}
