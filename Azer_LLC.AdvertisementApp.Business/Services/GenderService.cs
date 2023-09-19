using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azer_LLC.AdvertisementApp.Business.Interfaces;
using Azer_LLC.AdvertisementApp.DataAccess.UnitOfWork;
using Azer_LLC.AdvertisementApp.Dtos;
using Azer_LLC.AdvertisementApp.Entities;

namespace Azer_LLC.AdvertisementApp.Business.Services
{
    public class GenderService : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {       
            public GenderService(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
            {
            }        
    }
}
