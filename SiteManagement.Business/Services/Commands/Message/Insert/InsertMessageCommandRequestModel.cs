using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Services.Commands.Message.Insert
{
    public class InsertMessageCommandRequestModel : IRequest<ResponseItem>
    {
        public int SourceUserId { get; set; }
        public int DestinationUserId { get; set; }
        public string Messages { get; set; }
    }
}
