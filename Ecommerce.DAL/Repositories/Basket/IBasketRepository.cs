using Ecommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Basket
{
    public interface IBasketRepository
    {
        Task<CustomerBasket>  GetBasket(string basketId);
        Task<CustomerBasket> SetBasket(CustomerBasket Basket);
        Task<bool> DeleteBasket(string basketId);
    }
}
