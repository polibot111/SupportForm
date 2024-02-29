using DataAccess.Abstracts.Repositories.Endpoint;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Endpoint
{
    public class EndpointWriteRepo : WriteRepository<Entity.Entities.Endpoint>,IEndpointWriteRepo
    {
        public EndpointWriteRepo(AppDbContext context):base(context)
        {
                
        }
    }
}
