using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.Expense.Insert
{
    public class InsertExpenseCommandRequestModel : IRequest<ResponseItem>
    {
        public int ExpenseTypeId { get; set; }
        public float Amount { get; set; }
        public bool PaymentStatus { get; set; }
        public int HomeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
    }
}
