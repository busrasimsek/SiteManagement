using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Home.GetAll
{
    public class GetAllHomeQueryRequestModel : IRequest<ResponseItem<List<GetAllHomeQueryResponseModel>>>
    {
    }
}
