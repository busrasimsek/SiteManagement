using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Message.SeenAndGetByDestionationId
{
    public class SeenAndGetByDestionationIdCommandHandler : IRequestHandler<SeenAndGetByDestionationIdCommandRequestModel, ResponseItem<List<SeenAndGetByDestionationIdCommandResponseModel>>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SeenAndGetByDestionationIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseItem<List<SeenAndGetByDestionationIdCommandResponseModel>>> Handle(SeenAndGetByDestionationIdCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var messages = await _unitOfWork.Repository<IMessageRepository>().Query().Where(x => x.DestinationUserId == request.SourceUserId && x.SourceUserId == request.DestinationUserId).ToListAsync();
            messages.ForEach(x =>
            {
                x.IsSeen = true;
            });
            _unitOfWork.OpenTransaction();
            foreach(var message in messages)
            {
                _unitOfWork.Repository<IMessageRepository>().Update(message);
            }
            if (await _unitOfWork.SaveChangesAsync() < 1)
            {
                _unitOfWork.Rollback();
                return response.Error<List<SeenAndGetByDestionationIdCommandResponseModel>>(MessageCodesEnum.Error);
            }
            _unitOfWork.Commit();

            var query = await (
                    from message in _unitOfWork.Repository<IMessageRepository>().Query()
                    join user in _unitOfWork.Repository<IUserRepository>().Query() on message.SourceUserId equals user.Id
                    where message.DestinationUserId == request.DestinationUserId && message.SourceUserId == request.SourceUserId
                    select new SeenAndGetByDestionationIdCommandResponseModel
                    {
                        Username = user.Username,
                        Message = message.Messages,
                        Date = message.Date
                    }
                ).Union(
                from message in _unitOfWork.Repository<IMessageRepository>().Query()
                join user in _unitOfWork.Repository<IUserRepository>().Query() on message.SourceUserId equals user.Id
                where message.DestinationUserId == request.SourceUserId && message.SourceUserId == request.DestinationUserId
                select new SeenAndGetByDestionationIdCommandResponseModel
                {
                    Username = user.Username,
                    Message = message.Messages,
                    Date = message.Date
                }
                ).OrderByDescending(x=> x.Date).ToListAsync();
            return response.Ok(query.DistinctBy(x => new { x.Date, x.Message }).ToList());
        }
    }
}
