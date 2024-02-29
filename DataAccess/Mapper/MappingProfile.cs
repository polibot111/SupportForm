using AutoMapper;
using DataAccess.DTOs;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SupportForm, SupportFormDTO>().
                ForMember(x => x.Username, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null))
                .ForMember(x => x.SupportFormStatus, opt => opt.MapFrom(src => src.FormStatus.Value))
                .ForMember(x => x.Date, opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<Role,RoleDTO>()
                 .ForMember(x => x.RoleName, opt => opt.MapFrom(src => src.Name));
            CreateMap<User, UserDTO>()
                .ForMember(x => x.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.Name: null));
            CreateMap<FormStatus, FormStatusDTO>();
        }
    }
}
