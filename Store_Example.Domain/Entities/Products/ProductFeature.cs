using Store_Example.Domain.Entities.Commons;

namespace Store_Example.Domain.Entities.Products;

public class ProductFeature : BaseEntity
{
    public string DisplayName { get; set; }
    public string Value { get; set; }

    public Product Product { get; set; }

    public long ProductId { get; set; }


}