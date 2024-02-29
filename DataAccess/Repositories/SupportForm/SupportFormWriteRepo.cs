using DataAccess.Abstracts.Repositories.SupportForm;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.SupportForm
{
    public class SupportFormWriteRepo : WriteRepository<Entity.Entities.SupportForm>, ISupportFormWriteRepo
    {
        public SupportFormWriteRepo(AppDbContext context):base(context) 
        {
                
        }
    }
}
