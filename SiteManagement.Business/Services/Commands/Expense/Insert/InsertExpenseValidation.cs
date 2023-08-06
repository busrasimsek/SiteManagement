using FluentValidation;

namespace SiteManagement.Business.Services.Commands.Expense.Insert
{
    public class InsertExpenseValidation : AbstractValidator<InsertExpenseCommandRequestModel>
    {
        public InsertExpenseValidation()
        {
            RuleFor(e => e.ExpenseTypeId).NotEmpty().NotNull();
            RuleFor(e => e.HomeId).NotEmpty().NotNull();
            RuleFor(e=> e.Amount).Must(s => s >= 0)
                    .WithMessage("Ödeme tutarı bilgisi negatif olamaz!");

        }
    }
}
