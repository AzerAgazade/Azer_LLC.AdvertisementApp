using AutoMapper;
using Azer_LLC.AdvertisementApp.Business.Interfaces;
using Azer_LLC.AdvertisementApp.Common;
using Azer_LLC.AdvertisementApp.DataAccess.UnitOfWork;
using Azer_LLC.AdvertisementApp.Dtos;
using Azer_LLC.AdvertisementApp.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azer_LLC.AdvertisementApp.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
           var data = await _uow.GetRepository<Advertisement>().GetAllAsync(x=>x.Status,x=>x.CreatedDate,OrderByType.DESC);
           var dto = _mapper.Map<List<AdvertisementListDto>>(data);
           return new Response<List<AdvertisementListDto>>(ResponseType.Success, dto);
        }
    }
}
