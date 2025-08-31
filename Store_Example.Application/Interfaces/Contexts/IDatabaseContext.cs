using Microsoft.EntityFrameworkCore;
using Store_Example.Domain.Entities.Products;
using Store_Example.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Example.Application.Interfaces.Contexts
{
	public interface IDatabaseContext
	{
		public DbSet<User> users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFile> ProductFiles { get; set; }


		int SaveChanges(bool acceptAllChangesOnSuccess);
		int SaveChanges();
		Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
	}
}
