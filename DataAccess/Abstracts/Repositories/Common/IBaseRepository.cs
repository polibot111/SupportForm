using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Repositories.Common
{
    public interface IBaseRepository<T> where T : class
    {
        DbSet<T> Table { get; }
    }
}
