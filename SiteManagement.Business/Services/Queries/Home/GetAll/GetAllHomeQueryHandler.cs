using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Home.GetAll
{
    public class GetAllHomeQueryHandler : IRequestHandler<GetAllHomeQueryRequestModel, ResponseItem<List<GetAllHomeQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllHomeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem<List<GetAllHomeQueryResponseModel>>> Handle(GetAllHomeQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IHomeRepository>().Query().Where(x=> x.IsActive && x.IsDeleted == false).ToListAsync();
            return response.Ok(_mapper.Map<List<GetAllHomeQueryResponseModel>>(data));
        }
    }
}
