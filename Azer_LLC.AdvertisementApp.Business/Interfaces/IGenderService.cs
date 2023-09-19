using Azer_LLC.AdvertisementApp.Dtos;
using Azer_LLC.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azer_LLC.AdvertisementApp.Business.Interfaces
{
    public interface IGenderService : IService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>
    {
    }
}
