using AutoMapper;
using MediatR;
using SiteManagement.Core.Response;
using SiteManagement.Data.Core.UnitOfWork.Concrete;
using SiteManagement.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Business.Future.Commands.User.Insert
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommandRequestModel, ResponseItem>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InsertUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseItem> Handle(InsertUserCommandRequestModel request, CancellationToken cancellationToken)
        {
            var response = new ResponseItemManager();
            var pass = "123"; // generate edilecek
            var user = _mapper.Map<Data.Entity.User>(request);
            user.Password = pass; // bu kullanıcının mailine gidecek.
            _unitOfWork.OpenTransaction();
            _unitOfWork.Repository<IUserRepository>().Add(user);

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
