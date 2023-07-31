﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Future.Queries.User.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequestModel, ResponseItem<List<GetAllUserQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem<List<GetAllUserQueryResponseModel>>> Handle(GetAllUserQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IUserRepository>().Query().ToListAsync();
            return response.Ok(_mapper.Map<List<GetAllUserQueryResponseModel>>(data));
        }
    }
}
