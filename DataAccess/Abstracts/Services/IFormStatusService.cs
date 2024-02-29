using DataAccess.DTOs;
using DataAccess.Request.FormStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Services
{
    public interface IFormStatusService
    {
        Task<bool> AddFormStatus(FormStatusInsertCommand request);
        Task<IQueryable<FormStatusDTO>> GetAll();
    }
}
