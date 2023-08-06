using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Expense.Update
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(UpdateExpenseCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var expense = await _unitOfWork.Repository<IExpenseRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (expense is null)
            {
                return response.Error(MessageCodesEnum.NotFoundIdError);
            }
            _mapper.Map(request, expense);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IExpenseRepository>().Update(expense);
            if (await _unitOfWork.SaveChangesAsync() < 1)
            {
                _unitOfWork.Rollback();
                return response.Error(MessageCodesEnum.UpdatedError);
            }
            _unitOfWork.Commit();
            return response.Ok();
        }
    }
}
