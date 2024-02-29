using DataAccess.DTOs;
using DataAccess.Request.User;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Services
{
    public interface IUserService
    {
        Task<IQueryable<UserDTO>> GetAllAdmins();
        Task<IQueryable<UserDTO>> GetAllMembers();

        Task<bool> UpdateUserRole(UserCommandForUserRole user);
        Task<bool> UpdatePassword(UserCommandForPassword user);
        Task<bool> CreateUser(UserInsertCommand request);
        Task<bool> DeleteUser(UserDeleteCommand request);
        Task UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenDate);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    }
}
