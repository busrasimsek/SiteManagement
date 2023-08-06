using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.ExpenseType.Insert
{
    public class InsertExpenseTypeCommandRequestModel : IRequest<ResponseItem>
    {
        public string TypeName { get; set; }
        public string? Description { get; set; }
        public int ApartmentId { get; set; }
    }
}
