using Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class SupportForm : BaseEntity
    {

        public User? User { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public FormStatus FormStatus { get; set; }

    }
}
