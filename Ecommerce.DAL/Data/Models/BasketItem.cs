using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Data.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int quentity { get; set; }
        public string PicUrl { get; set; } = string.Empty;
        public string Category { get; set;} = string.Empty;
    }
}
