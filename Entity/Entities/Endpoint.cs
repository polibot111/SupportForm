using Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Endpoint:BaseEntity
    {
        public Endpoint()
        {
            Roles = new List<Role>();
        }

        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }

        public string Menu { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
