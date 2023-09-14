
using Ecommerce.API.Middleware;
using Ecommerce.BL.Services.CategoryService;
using Ecommerce.BL.Services.ProductService;
using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

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
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}