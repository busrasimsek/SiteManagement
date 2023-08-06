using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.User.GetUserById
{
    public class GetUserByIdQueryRequestModel : IRequest<ResponseItem<GetUserByIdQueryResponseModel>>
    {
        public int Id { get; set; }
    }
}
