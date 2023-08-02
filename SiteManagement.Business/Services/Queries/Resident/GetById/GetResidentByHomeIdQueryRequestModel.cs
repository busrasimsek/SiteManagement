using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Resident.GetById
{
    public class GetResidentByHomeIdQueryRequestModel : IRequest<ResponseItem<List<GetResidentByHomeIdQueryResponseModel>>>
    {
        public int HomeId { get; set; }
    }
}
