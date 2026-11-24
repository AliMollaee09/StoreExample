namespace Store_Example.Application.Services.Products.Queries.GetMenuItem
{
    public class ResultGetAllMenuItemDto
    {
        public long CatId { get; set; }

        public string Name { get; set; }

        public List<ResultGetAllMenuItemDto> Childs { get; set; }
    }
}
