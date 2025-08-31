using Store_Example.Domain.Entities.Commons;

namespace Store_Example.Domain.Entities.Products;

public class ProductFile : BaseEntity
{
    public byte[] Bytes { get; set; }

    public Product Product { get; set; }

    public long ProductId { get; set; }


}