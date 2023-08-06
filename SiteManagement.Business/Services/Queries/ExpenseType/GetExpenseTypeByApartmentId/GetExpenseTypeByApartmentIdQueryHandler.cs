using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeByApartmentId
{
    public class GetExpenseTypeByApartmentIdQueryHandler : IRequestHandler<GetExpenseTypeByApartmentIdQueryRequestModel, ResponseItem<List<GetExpenseTypeByApartmentIdQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetExpenseTypeByApartmentIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem<List<GetExpenseTypeByApartmentIdQueryResponseModel>>> Handle(GetExpenseTypeByApartmentIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IExpenseTypeRepository>().Query().Where(x => x.ApartmentId == request.ApartmentId && x.IsActive && x.IsDeleted == false).ToListAsync();
            return response.Ok(_mapper.Map<List<GetExpenseTypeByApartmentIdQueryResponseModel>>(data));
        }
    }
}
