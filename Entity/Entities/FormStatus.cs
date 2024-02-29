using Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class FormStatus:BaseEntity
    {
        public string Value { get; set; }
        public int Code { get; set; }
    }
}
