using Infrastructure.DTOs;
using Infrastructure.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface ILoginOperations
    {
        Task<UserToken> Login(LoginRequest request);
        Task<UserToken> RefreshTokenLogin(LoginWithRefreshTokenRequest refreshToken);
    }
}
