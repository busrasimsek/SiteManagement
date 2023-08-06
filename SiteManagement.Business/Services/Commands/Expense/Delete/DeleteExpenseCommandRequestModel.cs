using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.Expense.Delete
{
    public class DeleteExpenseCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
