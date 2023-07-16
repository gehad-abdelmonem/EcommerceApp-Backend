using AutoMapper;
using Ecommerce.BL.Dtos.Product;
using Ecommerce.DAL.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ReadProductDto, string>
    {
        private readonly IConfiguration configuration;
        public ProductUrlResolver(IConfiguration _configuration)
        {
            configuration= _configuration;
        }
        public string Resolve(Product source, ReadProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return configuration["ApiUrl"]+source.PictureUrl;
            }
            return null;
        }
    }
}
