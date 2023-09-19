using Azer_LLC.AdvertisementApp.Common.Enums;
using Azer_LLC.AdvertisementApp.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azer_LLC.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            this.RuleFor(x => x.AdvertisementAppUserStatusId).NotEmpty();
            this.RuleFor(x => x.AdvertisementId).NotEmpty();
            this.RuleFor(x => x.AppUserId).NotEmpty();
            this.RuleFor(x => x.CvPath).NotEmpty().WithMessage("Select a cv file.");
            this.RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Postponed).WithMessage("Postponement date cannot be empty");
        }
    }
}
