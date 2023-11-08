using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.Product
{
    public record WriteProductDto(string Name,string Description, double Price, string PictureUrl, int categoryId);


}
