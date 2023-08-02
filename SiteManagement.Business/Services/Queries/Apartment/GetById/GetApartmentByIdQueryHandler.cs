﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Apartment.GetById
{
    public class GetApartmentByIdQueryHandler : IRequestHandler<GetApartmentByIdQueryRequestModel, ResponseItem<GetApartmentByIdQueryResponseModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetApartmentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ResponseItem<GetApartmentByIdQueryResponseModel>> Handle(GetApartmentByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IApartmentRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (data == null)
            {
                return response.Error<GetApartmentByIdQueryResponseModel>(MessageCodesEnum.NotFoundIdError);
            }
            return response.Ok(_mapper.Map<GetApartmentByIdQueryResponseModel>(data));
        }
    }
}
