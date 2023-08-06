using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Apartment.Update
{
    public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateApartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(UpdateApartmentCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var apartment = await _unitOfWork.Repository<IApartmentRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (apartment is null)
            {
                return response.Error(MessageCodesEnum.NotFoundIdError);
            }
            _mapper.Map(request, apartment);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IApartmentRepository>().Update(apartment);
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
