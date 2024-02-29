using DataAccess.Abstracts.Services;
using DataAccess.Contexts;
using Entity.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class DummyDataCreater
    {
        public DummyDataCreater(IRoleService roleService, IUserService userService, IFormStatusService formStatusService, ISupportFormService supportFormService, IServiceProvider serviceProvider)
        {
            _roleService = roleService;
            _userService = userService;
            _formStatusService = formStatusService;
            _supportFormService = supportFormService;
            _serviceProvider = serviceProvider;

        }
        readonly IRoleService _roleService;
        readonly IUserService _userService;
        readonly IFormStatusService _formStatusService;
        readonly ISupportFormService _supportFormService;
        readonly IServiceProvider _serviceProvider;


        public async Task Create()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (!dbContext.Roles.Any())
                {

                    await _roleService.CreateRoleAsync(new()
                    {
                        RoleName = "Admin"
                    });

                    await _roleService.CreateRoleAsync(new()
                    {
                        RoleName = "Member"
                    });


                    await _userService.CreateUser(new()
                    {
                        UserName = "superadmin",
                        Email = "superadmin@admin.com",
                        Password = "123456"
                    });

                    await _userService.CreateUser(new()
                    {
                        UserName = "admin",
                        Email = "admin@admin.com",
                        Password = "123456"
                    });


                    await _userService.CreateUser(new()
                    {
                        UserName = "member",
                        Email = "member@member.com",
                        Password = "123456"
                    });

                    await _formStatusService.AddFormStatus(new()
                    {
                        FormStatuses = new List<FormStatus>()
                       {
                           new(){Value = "İşlem yapılmamış", Code = 0 },
                           new(){Value = "Okundu", Code = 1 },
                           new(){Value = "Cevaplandı", Code = 2 },
                           new(){Value = "Silindi", Code = 3 },
                       }
                    });


                    for (int i = 0; i < 30; i++)
                    {
                        await _supportFormService.AddFormToDummyDataCreater(new()
                        {
                            Username = "member",
                            Subject = $"Başlık {i}",
                            Message = $"Destek Mesajı => {i}"
                        });
                    }
                }
            }
        }
    }
}
