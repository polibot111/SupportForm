using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class SupportFormDTO
    {
        public string Username { get; set; }
        public string Subject { get; set; }
        public string SupportFormStatus { get; set; }
        public DateTime? Date { get; set; }
    }
}
