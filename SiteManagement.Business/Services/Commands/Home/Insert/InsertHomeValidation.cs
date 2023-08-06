using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Home.Insert
{
    public class InsertHomeValidation : AbstractValidator<InsertHomeCommandRequestModel>
    {
        public InsertHomeValidation()
        {
            RuleFor(h => h.ApartmentId).NotEmpty().NotNull();
            RuleFor(h => h.IsTenant).NotEmpty().NotNull();
            RuleFor(h => h.UserId).NotEmpty().NotNull();
            RuleFor(h => h.Status).NotEmpty().NotNull();
        }
    }
}
