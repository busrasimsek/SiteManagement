using FluentValidation;

namespace SiteManagement.Business.Services.Commands.ExpenseType.Update
{
    public class UpdateExpenseTypeValidation : AbstractValidator<UpdateExpenseTypeCommandRequestModel>
    {
        public UpdateExpenseTypeValidation()
        {
            RuleFor(e => e.TypeName).NotEmpty().NotNull();
            RuleFor(e => e.ApartmentId).NotEmpty().NotNull();
        }
    }
}
