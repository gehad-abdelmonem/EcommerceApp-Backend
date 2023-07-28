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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data
            List<Category> productsCategories = new List<Category>
            {
                new Category{Id =1,Name="Dresses"}
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
                    categoryId =1,
                   
                },
                new Product
                {
                    Id=2,
                    Name="Floral Dress",
                    Description="A colorful dress that suits you in your daily outings",
                    Price=900,
                    PictureUrl = "d2.jpg",
                    categoryId =1,
                },
                  new Product
                {
                    Id=3,
                    Name="Oversized Dress",
                    Description="Casual and practical dress",
                    Price=900,
                    PictureUrl = "d3.jpg",
                    categoryId =1,
                }
            };
            modelBuilder.Entity<Category>().HasData(productsCategories);
            modelBuilder.Entity<Product>().HasData(products);
            //product congigration
            new ProductConfigration().Configure(modelBuilder.Entity<Product>());

        }

    }

}
