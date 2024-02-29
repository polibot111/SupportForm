using DataAccess.DTOs;
using DataAccess.Request.AssignRoleEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IAuthorizationEndpointService
    {
        public Task<bool> AssignEndpointRoleAsync(AssignRoleEndpointInsertCommand request, Type type);

        public Task<List<EndpointsToRoleDTO>> GetEndpointAsync(AssignedEndpointToRoleQuery request);
    }
}
