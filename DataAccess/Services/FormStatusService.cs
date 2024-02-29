using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Abstracts.Repositories.FormStatus;
using DataAccess.Abstracts.Services;
using DataAccess.DTOs;
using DataAccess.Request.FormStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class FormStatusService : IFormStatusService
    {
        public FormStatusService(IFormStatusWriteRepo formStatusWriteRepo, IFormStatusReadRepo formStatusReadRepo, IMapper mapper)
        {
            _formStatusWriteRepo = formStatusWriteRepo;
            _formStatusReadRepo = formStatusReadRepo;
            _mapper = mapper;
        }
        public IFormStatusWriteRepo _formStatusWriteRepo { get; set; }
        public IFormStatusReadRepo _formStatusReadRepo { get; set; }
        public IMapper _mapper{ get; set; }
        public async Task<bool> AddFormStatus(FormStatusInsertCommand request)
        {
            bool response = await _formStatusWriteRepo.AddRangeAsync(request.FormStatuses);
            await _formStatusWriteRepo.SaveAsync();
            return response;
        }

        public async Task<IQueryable<FormStatusDTO>> GetAll()
        {
            var FormStatus = await _formStatusReadRepo.GetAllAsync();
            IQueryable<FormStatusDTO> result = FormStatus.ProjectTo<FormStatusDTO>(_mapper.ConfigurationProvider);
            return result;

        }
    }
}
