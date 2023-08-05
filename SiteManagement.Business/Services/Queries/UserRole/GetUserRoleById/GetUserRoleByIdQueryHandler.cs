using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.UserRole.GetUserRoleById
{
    public class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQueryRequestModel, ResponseItem<GetUserRoleByIdQueryResponseModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetUserRoleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ResponseItem<GetUserRoleByIdQueryResponseModel>> Handle(GetUserRoleByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IUserRoleRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            return response.Ok(_mapper.Map<GetUserRoleByIdQueryResponseModel>(data));
        }
    }
}
