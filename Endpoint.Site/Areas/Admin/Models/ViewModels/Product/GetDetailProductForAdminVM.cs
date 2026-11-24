using Store_Example.Application.Services.Products.Queries.GetDetailProductForAdmin;

namespace Endpoint.Site.Areas.Admin.Models.ViewModels.Product
{
    public class GetDetailProductForAdminVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public string Category { get; set; }
        public bool Displayed { get; set; }

        public ICollection<AddNewProduct_FeaturesVM> AddNewProduct_FeaturesVMs { get; set; }
        public ICollection<AddNewProduct_ImageVM> AddNewProduct_ImageVMs { get; set; }
    }
}

