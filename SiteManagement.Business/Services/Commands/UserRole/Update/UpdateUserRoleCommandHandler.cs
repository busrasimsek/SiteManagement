using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.UserRole.Update
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(UpdateUserRoleCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var userRole = await _unitOfWork.Repository<IUserRoleRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (userRole is null)
            {
                return response.Error(MessageCodesEnum.NotFoundIdError);
            }
            _mapper.Map(request, userRole);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserRoleRepository>().Update(userRole);
            if (await _unitOfWork.SaveChangesAsync() < 1)
            {
                _unitOfWork.Rollback();
                return response.Error(MessageCodesEnum.UpdatedError);
            }
            _unitOfWork.Commit();
            return response.Ok();
        }
    }
}
