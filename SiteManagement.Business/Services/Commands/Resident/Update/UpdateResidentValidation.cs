using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Resident.Update
{
    public class UpdateResidentValidation : AbstractValidator<UpdateResidentCommandRequestModel>
    {
        public UpdateResidentValidation()
        {
            RuleFor(r => r.Phone).NotEmpty().NotNull().Length(11).WithMessage("Telefon numarası 11 karakter olmalıdır");
            RuleFor(r => r.Firstname).NotEmpty().NotNull();
            RuleFor(r => r.HomeId).NotEmpty().NotNull();
            RuleFor(r => r.Email).NotEmpty().NotNull().EmailAddress();

        }
    }
}
