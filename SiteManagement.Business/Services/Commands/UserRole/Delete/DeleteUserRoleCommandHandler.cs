using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.UserRole.Delete
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseItem> Handle(DeleteUserRoleCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IUserRoleRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);

            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserRoleRepository>().Delete(data);
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
