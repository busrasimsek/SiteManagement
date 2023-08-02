using AutoMapper;
using MediatR;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Expense.Insert
{
    public class InsertExpenseCommandHandler : IRequestHandler<InsertExpenseCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertExpenseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(InsertExpenseCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();

            var expense = _mapper.Map<Data.Entity.Expense>(request);

            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IExpenseRepository>().Add(expense);

            if (await _unitOfWork.SaveChangesAsync() < 1)
            {
                _unitOfWork.Rollback();
                return response.Error(MessageCodesEnum.Error);
            }
            _unitOfWork.Commit();
            return response.Ok();
        }
    }
}
