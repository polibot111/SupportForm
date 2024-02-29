using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Request.SupportForm
{
    public class SupportFormInsertCommand
    {
        public string? Username { get; set; }
        public string Subject { get; set; }
        public string Message{ get; set; }

    }
}
