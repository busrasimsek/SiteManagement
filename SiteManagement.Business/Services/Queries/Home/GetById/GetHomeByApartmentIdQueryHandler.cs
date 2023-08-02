using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Business.Services.Queries.Apartment.GetById;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;
using System.Collections.Generic;

namespace SiteManagement.Business.Services.Queries.Home.GetById
{
    public class GetHomeByApartmentIdQueryHandler : IRequestHandler<GetHomeByApartmentIdQueryRequestModel, ResponseItem<List<GetHomeByApartmentIdQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetHomeByApartmentIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseItem<List<GetHomeByApartmentIdQueryResponseModel>>> Handle(GetHomeByApartmentIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IHomeRepository>().Query().Where(x => x.ApartmentId == request.ApartmentId).ToListAsync();
            if (data == null)
            {
                return response.Error<List<GetHomeByApartmentIdQueryResponseModel>>(MessageCodesEnum.NotFoundIdError);
            }
            return response.Ok(_mapper.Map<List<GetHomeByApartmentIdQueryResponseModel>>(data));
        }
    }
}
