using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class User: IdentityUser<string>
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDay { get; set; }

        public Role? Role { get; set; }

    }
}
