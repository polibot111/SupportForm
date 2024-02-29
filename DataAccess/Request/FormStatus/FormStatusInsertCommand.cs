using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Request.FormStatus
{
    public class FormStatusInsertCommand
    {

        public FormStatusInsertCommand()
        {
            FormStatuses = new List<Entity.Entities.FormStatus>();
        }
        public List<Entity.Entities.FormStatus> FormStatuses { get; set; }
    }
}
