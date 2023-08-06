using AutoMapper;
using MediatR;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.ExpenseType.Insert
{
    public class InsertExpenseTypeCommandHandler : IRequestHandler<InsertExpenseTypeCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertExpenseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(InsertExpenseTypeCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();

            var expenseType = _mapper.Map<Data.Entity.ExpenseType>(request);

            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IExpenseTypeRepository>().Add(expenseType);

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
