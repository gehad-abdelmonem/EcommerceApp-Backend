using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Basket
{
    public class CustomerBasketDto
    {
        public string Id { get; set; } = string.Empty;
        public List<BasketItemDto>? Items { get; set; } = new List<BasketItemDto>();
    }
}
