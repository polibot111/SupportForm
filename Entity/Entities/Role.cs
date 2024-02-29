﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Role:IdentityRole<string>
    {
        public Role()
        {
            Endpoint = new List<Endpoint>();
        }
        public ICollection<Endpoint> Endpoint { get; set; }
    }
}
