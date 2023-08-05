using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Business.Services.Queries.Expense.GetExpenseByHomeId;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Expense.GetByIGetExpenseByHomeIdd
{
    public class GetExpenseByHomeIdQueryHandler : IRequestHandler<GetExpenseByHomeIdQueryRequestModel, ResponseItem<List<GetExpenseByHomeIdQueryResponseModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetExpenseByHomeIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem<List<GetExpenseByHomeIdQueryResponseModel>>> Handle(GetExpenseByHomeIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IExpenseRepository>().Query().Where(x => x.HomeId == request.HomeId).ToListAsync();
            if (data == null)
            {
                return response.Error<List<GetExpenseByHomeIdQueryResponseModel>>(MessageCodesEnum.NotFoundIdError);
            }
            return response.Ok(_mapper.Map<List<GetExpenseByHomeIdQueryResponseModel>>(data));
        }
    }
}
