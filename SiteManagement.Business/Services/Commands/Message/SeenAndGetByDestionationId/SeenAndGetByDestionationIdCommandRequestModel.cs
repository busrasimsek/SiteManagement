using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.Message.SeenAndGetByDestionationId
{
    public class SeenAndGetByDestionationIdCommandRequestModel : IRequest<ResponseItem<List<SeenAndGetByDestionationIdCommandResponseModel>>>
    {
        public int SourceUserId { get; set; }
        public int DestinationUserId { get; set; }
    }
}
