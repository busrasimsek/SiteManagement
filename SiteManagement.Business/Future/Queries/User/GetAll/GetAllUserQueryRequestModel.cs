using MediatR;
using SiteManagement.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Future.Queries.User.GetAll
{
    public class GetAllUserQueryRequestModel : IRequest<ResponseItem<List<GetAllUserQueryResponseModel>>>
    {
    }
}
