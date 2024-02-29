using DataAccess.Abstracts.Services;
using DataAccess.Exceptions;
using Entity.Entities;
using Infrastructure.Abstracts;
using Infrastructure.DTOs;
using Infrastructure.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LoginOperations : ILoginOperations
    {
        public LoginOperations(IUserService userService, ITokenHandler tokenHandler, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        readonly IUserService _userService;
        readonly ITokenHandler _tokenHandler;
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;

        public async Task<UserToken> Login(LoginRequest request)
        {

            var user = await _userManager.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.UserName == request.Username);

            if (user == null)
                throw new Exception(ExceptionMessages.NotFoundUser);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                var token = _tokenHandler.CreateAccessToken(user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration);
                return token;
            }

            throw new Exception(ExceptionMessages.AuthAuthenticationFailed);
        }



        public async Task<UserToken> RefreshTokenLogin(LoginWithRefreshTokenRequest refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken.RefreshToken);

            if (user != null && user?.RefreshTokenEndDay > DateTime.UtcNow)
            {
                UserToken token = _tokenHandler.CreateAccessToken(user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration);
                return token;
            }

            throw new Exception(ExceptionMessages.NotFoundUser);
        }
    }
}
