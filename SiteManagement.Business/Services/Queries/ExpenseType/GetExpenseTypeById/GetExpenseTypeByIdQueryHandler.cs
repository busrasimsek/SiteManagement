using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.ExpenseType.GetExpenseTypeById
{
    public class GetExpenseTypeByIdQueryHandler : IRequestHandler<GetExpenseTypeByIdQueryRequestModel, ResponseItem<GetExpenseTypeByIdQueryResponseModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetExpenseTypeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ResponseItem<GetExpenseTypeByIdQueryResponseModel>> Handle(GetExpenseTypeByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IExpenseTypeRepository>().Query().Where(x => x.IsActive && x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == request.Id);
            return response.Ok(_mapper.Map<GetExpenseTypeByIdQueryResponseModel>(data));
        }
    }
}
