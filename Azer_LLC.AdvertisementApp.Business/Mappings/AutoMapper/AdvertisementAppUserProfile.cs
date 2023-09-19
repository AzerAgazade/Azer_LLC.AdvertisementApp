using AutoMapper;
using Azer_LLC.AdvertisementApp.Dtos;
using Azer_LLC.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azer_LLC.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AdvertisementAppUserProfile : Profile
    {
        public AdvertisementAppUserProfile()
        {
            CreateMap<AdvertisementAppUser, AdvertisementAppUserCreateDto>().ReverseMap();
            CreateMap<AdvertisementAppUser, AdvertisementAppUserListDto>().ReverseMap();
        }
    }
}
