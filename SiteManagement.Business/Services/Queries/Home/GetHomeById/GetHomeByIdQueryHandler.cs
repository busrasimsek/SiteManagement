using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Home.GetHomeById
{
    public class GetHomeByIdQueryHandler : IRequestHandler<GetHomeByIdQueryRequestModel, ResponseItem<GetHomeByIdQueryResponseModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetHomeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ResponseItem<GetHomeByIdQueryResponseModel>> Handle(GetHomeByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IHomeRepository>().Query().Where(x => x.IsActive && x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);
            return response.Ok(_mapper.Map<GetHomeByIdQueryResponseModel>(data));
        }
    }
}
