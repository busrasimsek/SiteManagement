using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Apartment.Delete
{
    public class DeleteApartmentCommandHandler : IRequestHandler<DeleteApartmentCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteApartmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseItem> Handle(DeleteApartmentCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IApartmentRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);

            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IApartmentRepository>().Delete(data);
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
