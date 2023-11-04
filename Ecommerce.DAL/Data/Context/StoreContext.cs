using Ecommerce.DAL.Configures;
using Ecommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Data.Context
{
    public class StoreContext:IdentityDbContext<ApplicationUser>
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            //seed superAdmin
            this.seedSuperAdmin(modelBuilder);

            //product congigration
            new ProductConfigration().Configure(modelBuilder.Entity<Product>());

        }
        public void seedSuperAdmin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "1",
                UserName = "Gehad",
                NormalizedUserName = "GEHAD",
                Email = "gehadabdelmonam@gmail.com",
                NormalizedEmail ="30@GMAIL.COM",
                Governorate = "Menofia",
                Adress = "shebin elkom, menofia",
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "p@ss0wrd")
            });

            var superAdminClaims = new List<IdentityUserClaim<string>>
            {
                new IdentityUserClaim<string>{Id=1,UserId="1",ClaimType = ClaimTypes.Role,ClaimValue = "superAdmin"},
                new IdentityUserClaim<string>{Id=2,UserId = "1",ClaimType=ClaimTypes.NameIdentifier ,ClaimValue = "1"}
            };
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(superAdminClaims);
        }

    }

}
