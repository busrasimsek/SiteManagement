using MediatR;
using SiteManagement.Core.Response;

namespace SiteManagement.Business.Future.Queries.User.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequestModel, ResponseItem<List<GetAllUserQueryResponseModel>>>
    {
        public GetAllUserQueryHandler()
        {
                
        }
        public Task<ResponseItem<List<GetAllUserQueryResponseModel>>> Handle(GetAllUserQueryRequestModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
