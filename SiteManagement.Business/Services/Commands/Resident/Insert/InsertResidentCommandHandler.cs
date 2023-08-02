using AutoMapper;
using MediatR;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.Resident.Insert
{
    public class InsertResidentCommandHandler : IRequestHandler<InsertResidentCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertResidentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(InsertResidentCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();

            var resident = _mapper.Map<Data.Entity.Resident>(request);

            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IResidentRepository>().Add(resident);

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
