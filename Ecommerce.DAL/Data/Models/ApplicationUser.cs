using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Adress { get; set; }= string.Empty;
        public string Governorate { get; set; } = string.Empty;
    }
}
