using FluentValidation;

namespace SiteManagement.Business.Services.Commands.ExpenseType.Insert
{
    public class InsertExpenseTypeValidation : AbstractValidator<InsertExpenseTypeCommandRequestModel>
    {
        public InsertExpenseTypeValidation()
        {
            RuleFor(e => e.TypeName).NotEmpty().NotNull();
            RuleFor(e => e.ApartmentId).NotEmpty().NotNull();
        }
    }
}
