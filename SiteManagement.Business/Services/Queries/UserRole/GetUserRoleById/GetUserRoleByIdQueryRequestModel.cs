using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.UserRole.GetUserRoleById
{
    public class GetUserRoleByIdQueryRequestModel : IRequest<ResponseItem<GetUserRoleByIdQueryResponseModel>>
    {
        public int Id { get; set; }
    }
}
