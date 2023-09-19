using Azer_LLC.AdvertisementApp.Common;
using Azer_LLC.AdvertisementApp.Dtos;
using Azer_LLC.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azer_LLC.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto,AdvertisementListDto,Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
