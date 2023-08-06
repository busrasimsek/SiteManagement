using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(UpdateUserCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var user = await _unitOfWork.Repository<IUserRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if(user is null)
            {
                return response.Error(MessageCodesEnum.UserNotFoundError);
            }
            _mapper.Map(request, user);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserRepository>().Update(user);
            if (await _unitOfWork.SaveChangesAsync() < 1)
            {
                _unitOfWork.Rollback();
                return response.Error(MessageCodesEnum.UserUpdatedError);
            }
            _unitOfWork.Commit();
            return response.Ok();
        }
    }
}
