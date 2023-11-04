using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Dtos.User
{
    public record RegisterDto (string UserName,string Email,string Password,string PhoneNumber,string Address,string Governorate);
}
