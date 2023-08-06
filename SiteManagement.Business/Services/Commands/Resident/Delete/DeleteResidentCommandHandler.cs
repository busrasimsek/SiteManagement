using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Resident.Delete
{
    public class DeleteResidentCommandHandler : IRequestHandler<DeleteResidentCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteResidentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseItem> Handle(DeleteResidentCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IResidentRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);

            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IResidentRepository>().Delete(data);
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
