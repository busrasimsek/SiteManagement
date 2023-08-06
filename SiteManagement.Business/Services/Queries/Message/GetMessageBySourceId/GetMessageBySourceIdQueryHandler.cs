using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Message.GetMessageBySourceId
{
    public class GetMessageBySourceIdQueryHandler : IRequestHandler<GetMessageBySourceIdQueryRequestModel, ResponseItem<List<GetMessageBySourceIdQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetMessageBySourceIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseItem<List<GetMessageBySourceIdQueryResponseModel>>> Handle(GetMessageBySourceIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var query = await (from m in _unitOfWork.Repository<IMessageRepository>().Query()
                         join u in _unitOfWork.Repository<IUserRepository>().Query() on m.DestinationUserId equals u.Id
                         where m.SourceUserId == request.SourceId
                         orderby m.Date descending
                         group new { m.IsSeen, m.DestinationUserId, u.Username } by new { m.DestinationUserId } into grp
                         select new GetMessageBySourceIdQueryResponseModel
                         {
                            DestionationUserId = grp.Key.DestinationUserId,
                            Username = grp.Select(x=> x.Username).FirstOrDefault(),
                            NotSeenMessageCount = grp.Count(x=> x.IsSeen == false),
                            IsSeen = grp.Count(x => x.IsSeen == false) <= 0
                         }
                         ).ToListAsync();

            return response.Ok(query);
        }
    }
}
