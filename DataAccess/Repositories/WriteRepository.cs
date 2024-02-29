using DataAccess.Abstracts.Repositories;
using DataAccess.Contexts;
using Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entity = await Table.AddAsync(model);
            return entity.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {

            EntityEntry<T> entity = Table.Remove(model);
            return entity.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }

       

        public async Task<bool> UpdateAsync(T model)
        {
            return await Task.Run(() =>
            {
                EntityEntry entity = Table.Update(model);
                return entity.State == EntityState.Modified;
            });
        }

   
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
