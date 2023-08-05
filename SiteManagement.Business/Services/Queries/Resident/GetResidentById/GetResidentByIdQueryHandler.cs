using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Resident.GetResidentById
{
    public class GetResidentByIdQueryHandler : IRequestHandler<GetResidentByIdQueryRequestModel, ResponseItem<GetResidentByIdQueryResponseModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetResidentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ResponseItem<GetResidentByIdQueryResponseModel>> Handle(GetResidentByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IResidentRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            return response.Ok(_mapper.Map<GetResidentByIdQueryResponseModel>(data));
        }
    }
}
