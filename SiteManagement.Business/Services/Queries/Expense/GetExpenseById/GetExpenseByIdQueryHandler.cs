using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Queries.Expense.GetExpenseById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQueryRequestModel, ResponseItem<GetExpenseByIdQueryResponseModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetExpenseByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ResponseItem<GetExpenseByIdQueryResponseModel>> Handle(GetExpenseByIdQueryRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var data = await _unitOfWork.Repository<IExpenseRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            return response.Ok(_mapper.Map<GetExpenseByIdQueryResponseModel>(data));
        }
    }
}
