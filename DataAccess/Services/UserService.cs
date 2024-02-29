using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure.Core;
using DataAccess.Abstracts.Repositories.Endpoint;
using DataAccess.Abstracts.Services;
using DataAccess.DTOs;
using DataAccess.Exceptions;
using DataAccess.Repositories.Endpoint;
using DataAccess.Request.User;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class UserService : IUserService
    {
        public UserService(UserManager<User> userManager, IConfiguration configuration, RoleManager<Role> roleManager, IEndpointReadRepo endpointReadRepo, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _endpointReadRepo = endpointReadRepo;
            _mapper = mapper;
        }

        readonly UserManager<User> _userManager;
        readonly RoleManager<Role> _roleManager;
        readonly IMapper _mapper;

        readonly IConfiguration _configuration;
        readonly IEndpointReadRepo _endpointReadRepo;
        public async Task<bool> CreateUser(UserInsertCommand request)
        {
            var result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email

            }, request.Password);

            if (result.Succeeded)
            {
                return result.Succeeded;
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in result.Errors)
                {
                    sb.AppendLine(item.Description);
                }

                string response = sb.ToString();
                throw new Exception(response);
            }
        }

        public async Task<bool> UpdatePassword(UserCommandForPassword request)
        {
            User user = await _userManager.FindByIdAsync(request.Id);
            if (user != null)
            {

                IdentityResult result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

                if (result.Succeeded)
                {
                    return true;
                }
            }

            throw new Exception(ExceptionMessages.WrongPassword);
        }

        public async Task UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenDate)
        {
            if (user != null)
            {
                int expireDaye = Convert.ToInt32(_configuration["RefreshTokenExpireDay"]);
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDay = DateTime.UtcNow.AddDays(expireDaye);

                await _userManager.UpdateAsync(user);
            }
            else
                throw new Exception(ExceptionMessages.NotFoundUser);
        }

        public async Task<bool> UpdateUserRole(UserCommandForUserRole request)
        {
            User user = await _userManager.FindByIdAsync(request.UserId);
            if (user != null)
            {
                user.Role = await _roleManager.FindByIdAsync(request.RoleId);
                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return true;
                }

            }
            throw new Exception(ExceptionMessages.NotFoundUser);
        }
        public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            User? userWithRole = await _userManager.Users.Include(x => x.Role).FirstOrDefaultAsync(u => u.UserName == name);

            if (userWithRole.Role == null) return false;

            Endpoint? endpoint = await _endpointReadRepo.Table
                .Include(e => e.Roles)
                .FirstOrDefaultAsync(e => e.Code == code);

            if (endpoint == null) return false;

            return true;

        }

        public async Task<IQueryable<UserDTO>> GetAllAdmins()
        {
            var Users = await _userManager.Users.Include(x => x.Role).Where(x => x.Role.Name == "Admin").ToListAsync();
            IQueryable<UserDTO> result = Users.AsQueryable().ProjectTo<UserDTO>(_mapper.ConfigurationProvider);
            return result;
        }

        public async Task<IQueryable<UserDTO>> GetAllMembers()
        {
            var Users = await _userManager.Users.Include(x => x.Role).Where(x => x.Role.Name != "Admin").ToListAsync();
            IQueryable<UserDTO> result = Users.AsQueryable().ProjectTo<UserDTO>(_mapper.ConfigurationProvider);
            return result;
        }

        public async Task<bool> DeleteUser(UserDeleteCommand request)
        {
            var UserWillDelete = await _userManager.Users.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var result = await _userManager.DeleteAsync(UserWillDelete);
            if (result.Succeeded)
            {
                return result.Succeeded;
            }

            return false;

        }
    }
}
