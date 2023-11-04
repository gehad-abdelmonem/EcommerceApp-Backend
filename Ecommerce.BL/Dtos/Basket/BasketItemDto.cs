using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Basket
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [Range(1,double.MaxValue,ErrorMessage ="Price Must Be Greater Than Zero")]
        public double Price { get; set; }
        [Required]
        public int quentity { get; set; }
        [Required]
        public string PicUrl { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
    }
}
