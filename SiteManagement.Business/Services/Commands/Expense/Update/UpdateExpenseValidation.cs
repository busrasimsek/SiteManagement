using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Expense.Update
{
    public class UpdateExpenseValidation : AbstractValidator<UpdateExpenseCommandRequestModel>
    {
        public UpdateExpenseValidation()
        {
            RuleFor(e => e.ExpenseTypeId).NotEmpty().NotNull();
            RuleFor(e => e.HomeId).NotEmpty().NotNull();
            RuleFor(e => e.Amount).Must(s => s >= 0)
                    .WithMessage("Ödeme tutarı bilgisi negatif olamaz!");
            RuleFor(e => e.DueDate).NotEmpty().NotNull();
            RuleFor(e => e.Date).NotEmpty().NotNull();
        }
    }
}
