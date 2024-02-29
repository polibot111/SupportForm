using DataAccess.Abstracts.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Repositories
{
    public interface IReadRepository<T>: IBaseRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(bool tracking = true);
     
        Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
