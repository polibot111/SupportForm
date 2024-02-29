using DataAccess.Abstracts.Repositories;
using DataAccess.Contexts;
using Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; set; }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<IQueryable<T>> GetAllAsync(bool tracking = true)
        {
            return await Task.Run(() =>
            {
                IQueryable<T> query = Table.AsQueryable();
                if (!tracking)
                    query = query.AsNoTracking();

                return query;
            });

        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await Table.FindAsync(Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return await Task.Run(() =>
            {
                var query = Table.Where(method);
                if (!tracking)
                    query = query.AsNoTracking();
                return query;
            });
        }
    }
}
