using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Data.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Basket
{
    public class BasketRepository : IBasketRepository
    {
         private readonly IDatabase _database; // interface called Idatabase inside the redis
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database  = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasket(string basketId)
        {
            
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasket(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> SetBasket(CustomerBasket Basket)
        {
            var created = await _database.StringSetAsync(Basket.Id, JsonSerializer.Serialize(Basket), TimeSpan.FromDays(30));
            if (!created) return null;
            else
                return await GetBasket(Basket.Id);
        }
    }
}
