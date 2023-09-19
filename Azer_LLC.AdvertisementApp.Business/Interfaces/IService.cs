using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azer_LLC.AdvertisementApp.Common;
using Azer_LLC.AdvertisementApp.Dtos.Interfaces;
using Azer_LLC.AdvertisementApp.Entities;

namespace Azer_LLC.AdvertisementApp.Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity

    {
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
    }
}
