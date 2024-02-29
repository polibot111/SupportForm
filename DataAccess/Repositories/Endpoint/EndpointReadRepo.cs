using DataAccess.Abstracts.Repositories.Endpoint;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Endpoint
{
    public class EndpointReadRepo :ReadRepository<Entity.Entities.Endpoint>, IEndpointReadRepo
    {
        public EndpointReadRepo(AppDbContext context):base(context) 
        {
                
        }
    }
}
