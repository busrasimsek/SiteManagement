using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;

namespace SiteManagement.Business.Services.Commands.UserRole.Insert
{
    public class InsertUserRoleCommandHandler : IRequestHandler<InsertUserRoleCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(InsertUserRoleCommandRequestModel request, CancellationToken cancellationToken)
        {

            var response = new ResponseItemManager();

            var userRole = _mapper.Map<Data.Entity.UserRole>(request);
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserRoleRepository>().Add(userRole);

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
