using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL.Data.Models;
using Ecommerce.DAL.Repositories.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryReposiory
    {
        private readonly StoreContext context;
        public CategoryRepository(StoreContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
