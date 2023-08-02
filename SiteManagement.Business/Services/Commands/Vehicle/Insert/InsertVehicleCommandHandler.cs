using AutoMapper;
using MediatR;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Vehicle.Insert
{
    public class InsertVehicleCommandHandler : IRequestHandler<InsertVehicleCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertVehicleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(InsertVehicleCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();

            var vehicle = _mapper.Map<Data.Entity.Vehicle>(request);

            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IVehicleRepository>().Add(vehicle);

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
