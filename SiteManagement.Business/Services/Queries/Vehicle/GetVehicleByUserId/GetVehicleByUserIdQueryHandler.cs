﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Vehicle.GetVehicleByUserId
{
    public class GetVehicleByUserIdQueryHandler : IRequestHandler<GetVehicleByUserIdQueryRequestModel, ResponseItem<List<GetVehicleByUserIdQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetVehicleByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem<List<GetVehicleByUserIdQueryResponseModel>>> Handle(GetVehicleByUserIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IVehicleRepository>().Query().Where(x => x.UserId == request.UserId &&  x.IsActive && x.IsDeleted == false).ToListAsync();
            return response.Ok(_mapper.Map<List<GetVehicleByUserIdQueryResponseModel>>(data));
        }
    }
}
