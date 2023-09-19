using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azer_LLC.AdvertisementApp.Dtos;
using Azer_LLC.AdvertisementApp.Entities;

namespace Azer_LLC.AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService : IService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>
    {
        
    }
}
