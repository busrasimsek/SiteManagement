using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Apartment.Update
{
    public class UpdateApartmentValidation : AbstractValidator<UpdateApartmentCommandRequestModel>
    {
        public UpdateApartmentValidation()
        {
            RuleFor(a => a.Name)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen apartman boş geçmeyiniz.")
               .MaximumLength(100)
               .MinimumLength(3)
                   .WithMessage("Lütfen apartman 3 ile 100 karakter arasında giriniz.");

            RuleFor(a => a.ManagerId).NotEmpty()
                .NotNull()
                .WithMessage("Lütfen Yönetici Id sini boş geçmeyiniz.");
        }
    }
}
