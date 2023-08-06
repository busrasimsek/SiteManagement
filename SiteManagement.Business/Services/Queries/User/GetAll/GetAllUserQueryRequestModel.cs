using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.User.GetAll
{
    public class GetAllUserQueryRequestModel : IRequest<ResponseItem<List<GetAllUserQueryResponseModel>>>
    {
    }
}
