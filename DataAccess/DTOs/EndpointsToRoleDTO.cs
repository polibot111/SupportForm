using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class EndpointsToRoleDTO
    {
        public string Menu { get; set; }
        public Dictionary<string, string> EndpointCodeDesc { get; set; } = new Dictionary<string, string>();
    }
}
