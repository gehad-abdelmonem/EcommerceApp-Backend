
using Ecommerce.API.Middleware;
using Ecommerce.BL.Services.CategoryService;
using Ecommerce.BL.Services.ProductService;
using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories;
using Ecommerce.DAL.Repositories.Basket;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region connection string
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

       
            #region regeister servicess(repos)
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IproductService,ProductService>();
            builder.Services.AddScoped<ICategoryReposiory, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();
            #endregion


            #region identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 4;
                options.User.RequireUniqueEmail = true;
            })
                            .AddEntityFrameworkStores<StoreContext>();
            #endregion

            #region add authentication sachema
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "cool";
                options.DefaultChallengeScheme = "cool";
            })
            .AddJwtBearer("cool", options =>
            {
                var secretKeyString = builder.Configuration.GetValue<string>("secretKey");
                var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? "");
                var secretKey = new SymmetricSecurityKey(secretKeyInBytes);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            #region add autherization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdminOnly", policy => policy
                                                      .RequireClaim(ClaimTypes.Role, "superAdmin")
                                                      .RequireClaim(ClaimTypes.NameIdentifier));
                options.AddPolicy("AdminsOnly",policy=>policy
                                                       .RequireClaim(ClaimTypes.Role, "superAdmin", "admin")
                                                       .RequireClaim(ClaimTypes.NameIdentifier));
            });
            #endregion

            #region auto mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion


            #region Cors
            builder.Services.AddCors(options=>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });
            #endregion

            #region setting redis
            builder.Services.AddSingleton<IConnectionMultiplexer>(c=>
            {
                var options = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(options);
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //handiling exception middlware
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}