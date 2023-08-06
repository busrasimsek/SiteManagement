using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Vehicle.Insert
{
    public class InsertVehicleValidation : AbstractValidator<InsertVehicleCommandRequestModel>
    {
        public InsertVehicleValidation()
        {

            RuleFor(v => v.Plate).NotEmpty().NotNull();
            RuleFor(v => v.UserId).NotEmpty().NotNull();
            RuleFor(v => v.Model).NotEmpty().NotNull();
        }
    }
}