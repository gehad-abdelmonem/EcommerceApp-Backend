using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Helpers
{
    public class ProductParams
    {
        private const int MaxSize = 50;
        public int PageNumber { get; set; } = 1;
        public int _PageSize { get; set; } = 6;
        public int PageSize{
            get => _PageSize;
            set=> _PageSize =(value>MaxSize)?MaxSize:value;
                
        }
        public int? CategoryId { get; set; }
        public string? Sort { get; set; }
        public string? Search { get; set; }
    }
}
