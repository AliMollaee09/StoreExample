namespace Store_Example.Application.Services.Products.Queries.GetAllProductForSite
{
    public class GetAllProductForSiteDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public int  Price{ get; set; }

        public byte[] Image { get; set; }

        public int Star { get; set; }
    }
}
