using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Vehicle.Update
{
    public class UpdateVehicleValidation : AbstractValidator<UpdateVehicleCommandRequestModel>
    {
        public UpdateVehicleValidation()
        {
            RuleFor(v => v.Plate).NotEmpty().NotNull();
            RuleFor(v => v.UserId).NotEmpty().NotNull();
            RuleFor(v => v.Model).NotEmpty().NotNull();
        }
    }
}