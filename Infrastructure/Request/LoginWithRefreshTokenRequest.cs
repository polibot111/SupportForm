﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Request
{
    public class LoginWithRefreshTokenRequest
    {
        public string RefreshToken { get; set; }
    }
}
