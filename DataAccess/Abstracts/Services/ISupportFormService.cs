using DataAccess.DTOs;
using DataAccess.Request.SupportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Services
{
    public interface ISupportFormService
    {
        Task<IQueryable<SupportFormDTO>> GetAllForms();
        Task<bool> AddForm(SupportFormInsertCommand request);
    }
}
