using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Business.Services.Commands.Vehicle.Update;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Services.Commands.Vehicle.Update
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateVehicleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(UpdateVehicleCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var vehicle = await _unitOfWork.Repository<IVehicleRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (vehicle is null)
            {
                return response.Error(MessageCodesEnum.NotFoundIdError);
            }
            _mapper.Map(request, vehicle);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IVehicleRepository>().Update(vehicle);
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
