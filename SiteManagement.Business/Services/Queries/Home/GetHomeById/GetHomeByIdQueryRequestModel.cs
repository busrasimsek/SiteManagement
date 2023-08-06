using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Home.GetHomeById
{
    public class GetHomeByIdQueryRequestModel : IRequest<ResponseItem<GetHomeByIdQueryResponseModel>>
    {
        public int Id { get; set; }
    }
}
