using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Abstracts.Services;
using DataAccess.DTOs;
using DataAccess.Exceptions;
using DataAccess.Request.Role;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class RoleService : IRoleService
    {
        public RoleService(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        readonly RoleManager<Role> _roleManager;
        readonly private IMapper _mapper;
        public async Task<bool> CreateRoleAsync(RoleInsertCommand request)
        {
            #region RoleNameControl
            var existingRole = await _roleManager.FindByNameAsync(request.RoleName);
            if (existingRole != null)
            {
                throw new Exception(ExceptionMessages.RoleNameControl);
            }
            #endregion

            IdentityResult result = await _roleManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.RoleName
            });

            if (result.Succeeded)
            {
                return true;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var role in result.Errors)
            {
                sb.AppendLine(role.Description + "\n");
            }

            throw new Exception(sb.ToString());
        }

        public async Task<bool> DeleteRoleAsync(RoleDeleteCommand request)
        {
            Role? role = await _roleManager.FindByIdAsync(request.Id);
            if (role != null)
            {
              
                await _roleManager.DeleteAsync(role);
                return true;
            }
            return false;
        }

        public async Task<IQueryable<RoleDTO>> GetAllRoles()
        {
            try
            {
                List<Role> roles = await _roleManager.Roles.ToListAsync();
                IQueryable queryableRoles = roles.AsQueryable();
                IQueryable<RoleDTO> result = queryableRoles.ProjectTo<RoleDTO>(_mapper.ConfigurationProvider);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
       
        }
    }
}
