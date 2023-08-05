using MediatR;
using SiteManagement.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Services.Commands.Message.SeenAndGetByDestionationId
{
    public class SeenAndGetByDestionationIdCommandRequestModel : IRequest<ResponseItem<List<SeenAndGetByDestionationIdCommandResponseModel>>>
    {
        public int SourceUserId { get; set; }
        public int DestinationUserId { get; set; }
    }
}
