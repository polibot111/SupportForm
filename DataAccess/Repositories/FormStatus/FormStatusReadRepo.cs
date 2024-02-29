using DataAccess.Abstracts.Repositories.FormStatus;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.FormStatus
{
    public class FormStatusReadRepo : ReadRepository<Entity.Entities.FormStatus>, IFormStatusReadRepo
    {
        public FormStatusReadRepo(AppDbContext context): base(context) 
        {
                
        }
    }
}
