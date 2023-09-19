using AutoMapper;
using Azer_LLC.AdvertisementApp.Dtos.AppRoleDto;
using Azer_LLC.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azer_LLC.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppRoleProfile : Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRoleProfile, AppRoleListDto>().ReverseMap();
            CreateMap<AppRoleProfile, AppRoleCreateDto>().ReverseMap();
            CreateMap<AppRoleProfile, AppRoleUpdateDto>().ReverseMap();
        }
    }
}
