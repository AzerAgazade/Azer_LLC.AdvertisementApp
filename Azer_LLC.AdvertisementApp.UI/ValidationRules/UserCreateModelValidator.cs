using Azer_LLC.AdvertisementApp.Dtos;
using Azer_LLC.AdvertisementApp.UI.Models;
using FluentValidation;

namespace Azer_LLC.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator: AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Firstname must not be empty");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender must not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must not be empty");
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password not match");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname must not be empty");
            RuleFor(x => new {x.Username,x.Firstname}).Must(x=>!x.Username.Contains(x.Firstname)).WithMessage("Username contains firstname!").When(x=>x.Username!=null &&x.Firstname!=null);
            
        }
    }
}
