using AutoMapper;
using MediatR;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Message.Insert
{
    public class InsertMessageCommandHandler : IRequestHandler<InsertMessageCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertMessageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseItem> Handle(InsertMessageCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var message = new Data.Entity.Message
            {
                DestinationUserId = request.DestinationUserId,
                SourceUserId = request.SourceUserId,
                Date = DateTime.Now,
                IsSeen = false,
                Messages = request.Messages
            };
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IMessageRepository>().Add(message);
            if (await _unitOfWork.SaveChangesAsync() < 1)
            {
                _unitOfWork.Rollback();
                return response.Error(MessageCodesEnum.Error);
            }
            _unitOfWork.Commit();
            return response.Ok();
        }
    }
}
