using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Store_Example.Application.Interfaces.Contexts;
using Store_Example.Common.Roles;
using Store_Example.Domain.Entities.Commons;
using Store_Example.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Example.Domain.Entities.Products;

namespace Store_Example.Persistance.Contexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFile> ProductFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyQueryFilter(modelBuilder);
            SeedData(modelBuilder);
        }

        private static void ApplyQueryFilter(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Category>(x => x.HasQueryFilter(category => !category.IsRemoved));
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
        }

        public override int SaveChanges()
        {
            SetAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditFields()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e is { Entity: BaseEntity<long>, State: EntityState.Added or EntityState.Modified });

            foreach (var entry in entries)
            {
                var entity = (BaseEntity<long>)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.InsertTime = DateTime.Now;
                        entity.IsRemoved = false;
                        break;
                    case EntityState.Modified:
                        entity.UpdateTime = DateTime.Now;
                        break;
                }
            }
        }

    }
}
