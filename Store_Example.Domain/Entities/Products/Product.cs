using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Domain.Entities.Commons;

namespace Store_Example.Domain.Entities.Products
{
	public class Product:BaseEntity
	{
		public string Name { get; set; }

		public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }

        public Category Category { get; set; }

		public long CategoryId { get; set; }

		public ICollection<ProductFile> ImageFiles { get; set; }
		public ICollection<ProductFeature> ProductFeatures{ get; set; }



    }
}
