using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Home.Update
{
    public class UpdateHomeCommandHandler : IRequestHandler<UpdateHomeCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateHomeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(UpdateHomeCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var home = await _unitOfWork.Repository<IHomeRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (home is null)
            {
                return response.Error(MessageCodesEnum.NotFoundIdError);
            }
            _mapper.Map(request, home);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IHomeRepository>().Update(home);
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