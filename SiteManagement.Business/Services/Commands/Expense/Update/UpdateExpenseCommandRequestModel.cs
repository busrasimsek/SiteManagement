using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.Expense.Update
{
    public class UpdateExpenseCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public float Amount { get; set; }
        public bool PaymentStatus { get; set; }
        public int HomeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
    }
}
