using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Resident.Insert
{
    public class InsertResidentValidation : AbstractValidator<InsertResidentCommandRequestModel>
    {
        public InsertResidentValidation()
        {
            RuleFor(r =>r.Phone).NotEmpty().NotNull().Length(11).WithMessage("Telefon numarası 11 karakter olmalıdır");
            RuleFor(r => r.Firstname).NotEmpty().NotNull();
            RuleFor(r => r.HomeId).NotEmpty().NotNull();
        }
    }
}
