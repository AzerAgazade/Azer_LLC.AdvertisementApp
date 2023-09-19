using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azer_LLC.AdvertisementApp.Dtos;

namespace Azer_LLC.AdvertisementApp.Business.ValidationRules
{
    public class ProvidedServiceUpdateDtoValidator:AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
            RuleFor(x => x.Description).NotEmpty(); 
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
