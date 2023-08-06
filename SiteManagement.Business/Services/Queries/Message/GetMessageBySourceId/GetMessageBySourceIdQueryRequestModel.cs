using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Queries.Message.GetMessageBySourceId
{
    public class GetMessageBySourceIdQueryRequestModel : IRequest<ResponseItem<List<GetMessageBySourceIdQueryResponseModel>>>
    {
        public int SourceId { get; set; }
    }
}
