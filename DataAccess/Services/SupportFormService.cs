﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure.Identity;
using DataAccess.Abstracts.Repositories.FormStatus;
using DataAccess.Abstracts.Repositories.SupportForm;
using DataAccess.Abstracts.Services;
using DataAccess.DTOs;
using DataAccess.Request.SupportForm;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class SupportFormService : ISupportFormService
    {
        private ISupportFormReadRepo _readRepo { get; set; }
        private ISupportFormWriteRepo _writeRepo { get; set; }
        private readonly UserManager<User> _userManager;
        private IFormStatusReadRepo _readFormStatusRepo { get; set; }
        readonly private IMapper _mapper;
        public SupportFormService(ISupportFormReadRepo readRepo, ISupportFormWriteRepo writeRepo, IMapper mapper, UserManager<User> userManager, IFormStatusReadRepo readFormStatusRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
            _mapper = mapper;
            _userManager = userManager;
            _readFormStatusRepo = readFormStatusRepo;
        }

        public async Task<bool> AddForm(SupportFormInsertCommand request)
        {

            var formStatus = await _readFormStatusRepo.GetSingleAsync(x => x.Code == 0);


            var user = await _userManager.FindByNameAsync(request.Username);

            var result = await _writeRepo.AddAsync(new SupportForm
            {
                Subject = request.Subject,
                FormStatus = formStatus,
                Message = request.Message,
                User = user
            });

            await _writeRepo.SaveAsync();
            return result;

        }

        public async Task<IQueryable<SupportFormDTO>> GetAllForms()
        {

            var supportForms = await _readRepo.Table.Include(x => x.FormStatus).Include(x => x.User).ToListAsync();
            IQueryable<SupportFormDTO> response = supportForms.AsQueryable().ProjectTo<SupportFormDTO>(_mapper.ConfigurationProvider);
            return response;


        }

        public async Task<bool> AddFormToDummyDataCreater(SupportFormInsertCommand request)
        {
            var FormStatusList = await _readFormStatusRepo.GetAllAsync();
            var FormStatusList2 = await FormStatusList.ToListAsync();
            Random rnd = new Random();
            int sayi = rnd.Next(0,FormStatusList2.Count);
            var formStatus = FormStatusList2[sayi];

            var user = await _userManager.FindByNameAsync(request.Username);

            var result = await _writeRepo.AddAsync(new SupportForm
            {
                Subject = request.Subject,
                FormStatus = formStatus,
                Message = request.Message,
                User = user
            });

            await _writeRepo.SaveAsync();
            return result;

        }
    }
}
