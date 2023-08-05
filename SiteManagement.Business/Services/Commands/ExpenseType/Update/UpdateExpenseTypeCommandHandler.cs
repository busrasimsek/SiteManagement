using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.ExpenseType.Update
{
    public class UpdateExpenseTypeCommandHandler : IRequestHandler<UpdateExpenseTypeCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateExpenseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(UpdateExpenseTypeCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var expenseType = await _unitOfWork.Repository<IExpenseTypeRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (expenseType is null)
            {
                return response.Error(MessageCodesEnum.NotFoundIdError);
            }
            _mapper.Map(request, expenseType);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IExpenseTypeRepository>().Update(expenseType);
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
