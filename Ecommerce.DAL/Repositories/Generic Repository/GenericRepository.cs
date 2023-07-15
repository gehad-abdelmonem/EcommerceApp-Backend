using Ecommerce.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Generic_Repository
{
    public class GenericRepository<TEntity> : IGenerticRepository<TEntity> where TEntity : class
    {
        private readonly StoreContext context;
        public GenericRepository(StoreContext _context)
        {
            context = _context; 
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
    }
}
