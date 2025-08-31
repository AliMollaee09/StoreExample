using Microsoft.AspNetCore.Http;

namespace Store_Example.Application.Services.Products.Commands.AddNewProduct;

public class RequestAddNewProductDto
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Inventory { get; set; }
    public long CategoryId { get; set; }
    public bool Displayed { get; set; }

    //public List<AddNewProduct_ImageDto> Images { get; set; }
    public List<IFormFile> Images { get; set; }
    public List<AddNewProduct_FeaturesDto> Features { get; set; }
}