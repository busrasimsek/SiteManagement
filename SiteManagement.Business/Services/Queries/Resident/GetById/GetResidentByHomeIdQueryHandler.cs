﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Business.Services.Queries.Home.GetById;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Resident.GetById
{
    public class GetResidentByHomeIdQueryHandler : IRequestHandler<GetResidentByHomeIdQueryRequestModel, ResponseItem<List<GetResidentByHomeIdQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetResidentByHomeIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseItem<List<GetResidentByHomeIdQueryResponseModel>>> Handle(GetResidentByHomeIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IResidentRepository>().Query().Where(x => x.HomeId == request.HomeId).ToListAsync();
            if (data == null)
            {
                return response.Error<List<GetResidentByHomeIdQueryResponseModel>>(MessageCodesEnum.NotFoundIdError);
            }
            return response.Ok(_mapper.Map<List<GetResidentByHomeIdQueryResponseModel>>(data));
        }
    }
}