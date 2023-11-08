using AutoMapper;
using Ecommerce.BL.Dtos.Basket;
using Ecommerce.BL.Dtos.Product;
using Ecommerce.BL.Dtos.ProductCategory;
using Ecommerce.BL.Dtos.ProductType;
using Ecommerce.BL.Helpers;
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
            CreateMap<Product,ReadProductDto>()
               //.ForMember(d=>d.PictureUrl,src=>src.MapFrom<ProductUrlResolver>())
                .ReverseMap();
            CreateMap<Product,WriteProductDto>() .ReverseMap();
            CreateMap<ReadProductDto,WriteProductDto>();

            #endregion

            #region product Category
            CreateMap<Category,ReadCategoryDto>().ReverseMap();
            CreateMap<WriteCategoryDto,Category>().ReverseMap();
            #endregion

            #region basket
            CreateMap<BasketItem,BasketItemDto>().ReverseMap();
            CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();
            #endregion
        }
    }
}
