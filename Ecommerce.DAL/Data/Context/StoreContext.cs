using Ecommerce.DAL.Configures;
using Ecommerce.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Data.Context
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data
            List<ProductType> productsTypes = new List<ProductType>
            {
                new ProductType{Id =1,Name="Dresses"}
            };
            List<ProductBrand> productBrands = new List<ProductBrand>
            {
                new ProductBrand{Id=1,Name="Mlameh"}
            };
            List<Product> products = new List<Product>
            {
                new Product
                {   
                    Id=1,
                    Name="Open Dress",
                    Description="A delightful and precious open dress for your special outings",
                    Price=1120,
                    PictureUrl = "d1.jpg",
                    ProductTypeId =1,
                    ProductBrandId=1
                },
                new Product
                {
                    Id=2,
                    Name="Floral Dress",
                    Description="A colorful dress that suits you in your daily outings",
                    Price=900,
                    PictureUrl = "d1.jpg",
                    ProductTypeId =1,
                    ProductBrandId=1
                },
                  new Product
                {
                    Id=3,
                    Name="Oversized Dress",
                    Description="Casual and practical dress",
                    Price=900,
                    PictureUrl = "d1.jpg",
                    ProductTypeId =1,
                    ProductBrandId=1
                }
            };
            modelBuilder.Entity<ProductType>().HasData(productsTypes);
            modelBuilder.Entity<ProductBrand>().HasData(productBrands);
            modelBuilder.Entity<Product>().HasData(products);
            //product congigration
            new ProductConfigration().Configure(modelBuilder.Entity<Product>());

        }

    }

}
