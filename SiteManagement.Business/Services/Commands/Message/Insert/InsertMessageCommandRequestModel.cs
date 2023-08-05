using MediatR;
using SiteManagement.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Services.Commands.Message.Insert
{
    public class InsertMessageCommandRequestModel : IRequest<ResponseItem>
    {
        public int SourceUserId { get; set; }
        public int DestinationUserId { get; set; }
        public string Messages { get; set; }
    }
}
