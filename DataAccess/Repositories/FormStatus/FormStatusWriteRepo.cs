using DataAccess.Abstracts.Repositories.FormStatus;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.FormStatus
{
    public class FormStatusWriteRepo: WriteRepository<Entity.Entities.FormStatus>, IFormStatusWriteRepo
    {
        public FormStatusWriteRepo(AppDbContext context):base(context) 
        {
                
        }
    }
}
