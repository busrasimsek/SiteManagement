using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Resident.GetResidentById
{
    public class GetResidentByIdQueryRequestModel : IRequest<ResponseItem<GetResidentByIdQueryResponseModel>>
    {
        public int Id { get; set; }
    }
}
