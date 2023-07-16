using AutoMapper;
using Ecommerce.BL.Dtos.Product;
using Ecommerce.BL.Dtos.ProductBrand;
using Ecommerce.BL.Dtos.ProductType;
using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Auto_Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region product
            CreateMap<Product,ReadProductDto>().ReverseMap();
            #endregion

            #region product brand
            CreateMap<ProductBrand,ReadBrandDto>().ReverseMap();
            #endregion

            #region product Type
            CreateMap<ProductType,ReadTypeDto>().ReverseMap();
            #endregion
        }
    }
}
