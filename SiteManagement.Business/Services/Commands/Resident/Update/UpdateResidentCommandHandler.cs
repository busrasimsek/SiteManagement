using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Resident.Update
{
    public class UpdateResidentCommandHandler : IRequestHandler<UpdateResidentCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateResidentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(UpdateResidentCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var resident = await _unitOfWork.Repository<IResidentRepository>().Query().FirstOrDefaultAsync(x => x.Id == request.Id);
            if (resident is null)
            {
                return response.Error(MessageCodesEnum.NotFoundIdError);
            }
            _mapper.Map(request, resident);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IResidentRepository>().Update(resident);
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
