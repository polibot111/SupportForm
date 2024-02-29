using Entity.Entities;
using Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface ITokenHandler
    {
        UserToken CreateAccessToken(User user);
        string CreateRefreshToken();
    }
}
