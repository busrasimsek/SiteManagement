using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Home.Update
{
    public class UpdateHomeValidation : AbstractValidator<UpdateHomeCommandRequestModel>
    {
        public UpdateHomeValidation()
        {
            RuleFor(h => h.ApartmentId).NotEmpty().NotNull();
            RuleFor(h => h.IsTenant).NotEmpty().NotNull();
            RuleFor(h => h.UserId).NotEmpty().NotNull();
            RuleFor(h => h.Status).NotEmpty().NotNull();
        }
    }
}
