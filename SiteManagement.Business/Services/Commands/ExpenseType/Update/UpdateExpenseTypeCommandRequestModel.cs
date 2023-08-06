using MediatR;
using SiteManagement.Core.Response;
using System.Text.Json.Serialization;

namespace SiteManagement.Business.Services.Commands.ExpenseType.Update
{
    public class UpdateExpenseTypeCommandRequestModel : IRequest<ResponseItem>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string? Description { get; set; }
        public int ApartmentId { get; set; }
    }
}
