using DataAccess.DTOs;
using DataAccess.Request.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Services
{
    public interface IRoleService
    {
        Task<IQueryable<RoleDTO>> GetAllRoles();
        Task<bool> CreateRoleAsync(RoleInsertCommand request);
        Task<bool> DeleteRoleAsync(RoleDeleteCommand request);
    }
}
